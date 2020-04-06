using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FlexiComms.Api.Dto;
using FlexiComms.Data.Entities.Models;
using FlexiComms.Data.Repository.IdentityModels;
using FlexiComms.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FlexiComms.Api.Controllers
{
    [Route("api/registration/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly ILogger<RegistrationController> _logger;
        private readonly IIdentityRepository _identityRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IClientRoleRepository _clientRoleRepository;
        private readonly IMapper _mapper;
        public RegistrationController(ILogger<RegistrationController> logger, 
                                      IIdentityRepository identityRepository,
                                      IClientRepository clientRepository,
                                      IClientRoleRepository clientRoleRepository,
                                      IMapper mapper)
        {
            _logger = logger;
            _identityRepository = identityRepository;
            _clientRepository = clientRepository;
            _clientRoleRepository = clientRoleRepository;
            _mapper = mapper;
        }

        [HttpPost("/register")]
        public async Task<IActionResult> Register([FromBody]ClientDto client)
        {
            bool isUserExist = await _identityRepository.FindUserByEmailAsync(client.EmailAddress);
            if (!isUserExist)
            {
                client.ClientRoleId = await _clientRoleRepository.GetClientRoleIdByRoleTypeAsync(Data.Entities.Enums.RoleType.AdminRoleType);
                var clientCreated = _clientRepository.AddClient(_mapper.Map<Client>(client));
                if(clientCreated != null)
                {
                    client.ClientId = clientCreated.ClientId;
                    if(!string.IsNullOrEmpty(client.Company))
                        clientCreated.Companies.Add(_mapper.Map<Company>(new CompanyDto { Name = client.Company }));
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