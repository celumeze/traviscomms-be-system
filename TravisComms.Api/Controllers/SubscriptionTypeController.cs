using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravisComms.Api.Dto;
using TravisComms.Data.Repository.Interfaces;

namespace TravisComms.Api.Controllers
{
    [Route("api/subscriptiontypes")]
    [ApiController]
    public class SubscriptionTypeController : ControllerBase
    {
        private readonly ILogger<RegistrationController> _logger;
        private readonly ISubscriptionTypeRepository _subscriptionTypeRepository;   
        private readonly IMapper _mapper;
        public SubscriptionTypeController(ILogger<RegistrationController> logger,
                                      ISubscriptionTypeRepository subscriptionTypeRepository,
                                      IMapper mapper)
        {
            _logger = logger;
            _subscriptionTypeRepository = subscriptionTypeRepository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        [HttpHead]
        public async Task<IActionResult> GetSubscriptionTypesAsync()
        {
            var result =  _mapper.Map<List<SubscriptionTypeDto>>(await _subscriptionTypeRepository.GetSubscriptionTypesAsync());

            return Ok(result);
        }
    }
}