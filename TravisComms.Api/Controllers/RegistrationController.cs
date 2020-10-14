using System.Threading.Tasks;
using AutoMapper;
using TravisComms.Api.Dto;
using TravisComms.Data.Entities.Models;
using TravisComms.Data.Repository.IdentityModels;
using TravisComms.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using TravisComms.Messaging;
using TravisComms.Sender.Module;
using TravisComms.Api.Helpers;
using TravisComms.Messaging.MessageTypes;
using System;

namespace TravisComms.Api.Controllers
{
    [Route("api/register")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly ILogger<RegistrationController> _logger;
        private readonly IMapper _mapper;
        private readonly IEmailMessenger _emailMessenger;
        private readonly IRegistrationUoW _registrationUnitOfWork;
        private readonly ServiceBusConnectionConfig _serviceBusConfig;
        public RegistrationController(ILogger<RegistrationController> logger, 
                                      IMapper mapper,
                                      IRegistrationUoW registrationUnitOfWork,
                                      IOptionsSnapshot<ServiceBusConnectionConfig> serviceBusConfig,
                                      IEmailMessenger emailMessenger)
        {
            _logger = logger;
            _mapper = mapper;
            _registrationUnitOfWork = registrationUnitOfWork;
            _serviceBusConfig = serviceBusConfig.Value;
            _emailMessenger = emailMessenger;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]AddAccountHolderDto addAccountHolderDto)
        {
            bool isUserExist = await _registrationUnitOfWork.IdentityRepository.FindUserByEmailAsync(addAccountHolderDto?.EmailAddress);
            if (!isUserExist)
            {
                addAccountHolderDto.AccountHolderRoleId = await _registrationUnitOfWork.AccountHolderRoleRepository.GetAccountHolderRoleIdByRoleTypeAsync(Data.Entities.Enums.RoleType.AdminRoleType);
                var accountHolderCreated = _registrationUnitOfWork.AccountHolderRepository.AddAccountHolder(_mapper.Map<AccountHolder>(addAccountHolderDto)) ?? throw new Exception();                
                if(!string.IsNullOrEmpty(addAccountHolderDto.Company))
                     accountHolderCreated.Companies.Add(_mapper.Map<Company>(new CompanyDto { Name = addAccountHolderDto.Company }));
                 var userCreated = await _registrationUnitOfWork.IdentityRepository.CreateNewUserAsync(_mapper.Map<MainUser>(addAccountHolderDto), addAccountHolderDto.Password, 
                                               accountHolderCreated.AccountHolderId);
                 if (userCreated != null)
                 {
                     var emailVerificationCode = await _registrationUnitOfWork.IdentityRepository.GenerateEmailConfirmationCodeAsync(userCreated);
                     var callbackUrl = ControllerHelper.GenerateVerifyEmailLink(Url, ControllerContext, 
                                                            userCreated.Id, emailVerificationCode);
                    //send message
                    var message = new VerifyEmailCommand
                    {
                        CorrelationID = Guid.NewGuid(),
                        EmailAddress = addAccountHolderDto.EmailAddress,
                        FirstName = addAccountHolderDto.FirstName,
                        CallbackUrl = callbackUrl
                    };
                    await _emailMessenger.SendVerifyEmailCommand(message, _serviceBusConfig.AzureServiceBusConnectionString, _serviceBusConfig.EmailServiceConfig.QueueName);
                    return Ok(new ResponseMessageDto { SuccessMessage = "Please verify your email address to complete registration" });
                }
                                               
            }           
            return BadRequest(new ResponseMessageDto { ErrorMessage = "Unable to register at this time. Please try again" });
        }
    }
}