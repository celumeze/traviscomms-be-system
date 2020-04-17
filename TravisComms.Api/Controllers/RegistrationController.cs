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

namespace TravisComms.Api.Controllers
{
    [Route("api/registration/[controller]")]
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

        [HttpPost("/register")]
        public async Task<IActionResult> Register([FromBody]ClientDto client)
        {
            bool isUserExist = await _identityRepository.FindUserByEmailAsync(client.EmailAddress);
            if (!isUserExist)
            {
                client.ClientRoleId = await _accountHolderRoleRepository.GetAccountHolderRoleIdByRoleTypeAsync(Data.Entities.Enums.RoleType.AdminRoleType);
                var accountHolderCreated = _accountHolderRepository.AddAccountHolder(_mapper.Map<AccountHolder>(client));
                if(accountHolderCreated != null)
                {
                    client.ClientId = accountHolderCreated.AccountHolderId;
                    if(!string.IsNullOrEmpty(client.Company))
                        accountHolderCreated.Companies.Add(_mapper.Map<Company>(new CompanyDto { Name = client.Company }));
                    var isUserCreated = await _identityRepository.CreateNewUser(_mapper.Map<MainUser>(client), client.Password);
                    if (isUserCreated)
                    {
                        return Ok("Verify email to complete registration");
                    }
                }                               
            }           
            return BadRequest("Unable to register at this time");
        }
    }
}