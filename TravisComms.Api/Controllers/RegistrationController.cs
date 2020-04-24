using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TravisComms.Api.Dto;
using TravisComms.Data.Entities.Models;
using TravisComms.Data.Repository.IdentityModels;
using TravisComms.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace TravisComms.Api.Controllers
{
    [Route("api/register")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly ILogger<RegistrationController> _logger;
        private readonly IIdentityRepository _identityRepository;
        private readonly IAccountHolderRepository _accountHolderRepository;
        private readonly IAccountHolderRoleRepository _accountHolderRoleRepository;
        private readonly IMapper _mapper;
        public RegistrationController(ILogger<RegistrationController> logger, 
                                      IIdentityRepository identityRepository,
                                      IAccountHolderRepository accountHolderRepository,
                                      IAccountHolderRoleRepository accountHolderRoleRepository,
                                      IMapper mapper)
        {
            _logger = logger;
            _identityRepository = identityRepository;
            _accountHolderRepository = accountHolderRepository;
            _accountHolderRoleRepository = accountHolderRoleRepository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]AddAccountHolderDto addAccountHolderDto)
        {
            bool isUserExist = await _identityRepository.FindUserByEmailAsync(addAccountHolderDto.EmailAddress);
            if (!isUserExist)
            {
                addAccountHolderDto.AccountHolderRoleId = await _accountHolderRoleRepository.GetAccountHolderRoleIdByRoleTypeAsync(Data.Entities.Enums.RoleType.AdminRoleType);
                var accountHolderCreated = _accountHolderRepository.AddAccountHolder(_mapper.Map<AccountHolder>(addAccountHolderDto));
                if(accountHolderCreated != null)
                {
                    if(!string.IsNullOrEmpty(addAccountHolderDto.Company))
                        accountHolderCreated.Companies.Add(_mapper.Map<Company>(new CompanyDto { Name = addAccountHolderDto.Company }));
                    var isUserCreated = await _identityRepository.CreateNewUser(_mapper.Map<MainUser>(addAccountHolderDto), addAccountHolderDto.Password, 
                                               accountHolderCreated.AccountHolderId);
                    if (isUserCreated)
                    {                      
                          return Ok(new ResponseMessageDto { SuccessMessage = "Please verify your email address to complete registration" });
                    }
                }                               
            }           
            return BadRequest(new ResponseMessageDto { ErrorMessage = "Unable to register at this time. Please try again" });
        }
    }
}