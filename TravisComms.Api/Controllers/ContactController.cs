using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.Extensions.Logging;
using TravisComms.Api.Dto;
using TravisComms.Api.Middleware;
using TravisComms.Data.Entities.Models;
using TravisComms.Data.Repository.Interfaces;

namespace TravisComms.Api.Controllers
{
    
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

        [HttpGet]
        [Route("api/contacts")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> GetContacts()
        {
            var accountHolderId = User.Claims.FirstOrDefault(c => c.Type == "AccountHolderId")?.Value;
            if(!string.IsNullOrEmpty(accountHolderId))
            {
                var contacts = await _contactRepository.GetContactDetailsAsync(accountHolderId);
                return Ok(_mapper.Map<List<ContactDto>>(contacts.ToList()));
            }            
            return BadRequest();
        }

        [HttpPost]
        [Route("api/contact")]
        public async Task<IActionResult> AddContact([FromBody]AddContactDto newContact)
        {
            if(newContact != null)
            {
                var accountHolderIdClaim = User.Claims.FirstOrDefault(c => c.Type == "AccountHolderId")?.Value;
                newContact.AccountHolderId = !string.IsNullOrEmpty(accountHolderIdClaim) ? Guid.Parse(accountHolderIdClaim) : Guid.Empty;
                var newAddedContact = await _contactRepository.AddContactDetails(_mapper.Map<Contact>(newContact));
                if(newAddedContact != null)
                {
                    newAddedContact.AccountHolderId = Guid.Empty;
                    return Ok(newAddedContact);
                }
            }
            return BadRequest();
        }

        [HttpPatch]
        [Route("api/editcontact")]
        public async Task<IActionResult> EditContact([FromBody]ContactDto editContact)
        {
            if(editContact != null)
            {
                var accountHolderIdClaim = User.Claims.FirstOrDefault(c => c.Type == "AccountHolderId")?.Value;
                editContact.AccountHolderId = !string.IsNullOrEmpty(accountHolderIdClaim) ? Guid.Parse(accountHolderIdClaim) : Guid.Empty;
                var changedContact = await _contactRepository.EditContactDetails(_mapper.Map<Contact>(editContact));
                if(changedContact != null)
                {
                    changedContact.AccountHolderId = Guid.Empty;
                    return Ok(changedContact);
                }
            }
            return BadRequest();
        }
    }
}
