using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TravisComms.Api.Dto;
using TravisComms.Data.Entities.Models;
using TravisComms.Data.Repository.Interfaces;

namespace TravisComms.Api.Controllers
{
    [Route("api/contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;

        public ContactController(ILogger<ContactController> logger, IMapper mapper, IContactRepository contactRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _contactRepository = contactRepository;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AddContact([FromBody]AddContactDto newContact)
        {
            if(newContact != null)
            {
                var newAddedContact = await _contactRepository.AddContactDetails(_mapper.Map<Contact>(newContact));
                if(newAddedContact != null)
                {
                    return Ok(newAddedContact);
                }
            }
            return BadRequest();
        }
    }
}
