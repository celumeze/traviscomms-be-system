using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.Extensions.Logging;
using TravisComms.Api.Dto;
using TravisComms.Api.Helpers;
using TravisComms.Api.Middleware;
using TravisComms.CsvProcessing.Interfaces;
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
        private readonly IContactsResultProcessor _contactsResultProcessor;

        public ContactController(ILogger<ContactController> logger, IMapper mapper, 
            IContactRepository contactRepository, IContactsResultProcessor contactsResultProcessor)
        {
            _logger = logger;
            _mapper = mapper;
            _contactRepository = contactRepository;
            _contactsResultProcessor = contactsResultProcessor;
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

        [HttpPost, DisableRequestSizeLimit]
        [Route("api/uploadcontactscsv")]
        public async Task<IActionResult> UploadContactsCsv()
        {
                var nameValueCollection = Request.Form.AsNameValueCollection();
                var file = Request.Form.Files[0];
                var contactsCsvDto = ControllerHelper.CreateContactsCsvInfo(file, nameValueCollection);
                contactsCsvDto.accountHolderId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "AccountHolderId")?.Value);

                if (contactsCsvDto.file is object && contactsCsvDto.file.Length > 0 && 
                    !string.IsNullOrWhiteSpace(contactsCsvDto.ContactHeader.contactNumberHeader))
                {
                    contactsCsvDto.fileName = Path.GetTempFileName();

                    await using var stream = new FileStream(contactsCsvDto.fileName, FileMode.Open);

                    contactsCsvDto.fileStream = stream;

                    await contactsCsvDto.file.CopyToAsync(contactsCsvDto.fileStream);

                    contactsCsvDto.fileStream.Position = 0;

                    var contactRecords = await _contactsResultProcessor.UploadAsync(contactsCsvDto.fileStream, contactsCsvDto.ContactHeader,
                                                                contactsCsvDto.separatorText, contactsCsvDto.accountHolderId, contactsCsvDto.fileName);
                    System.IO.File.Delete(contactsCsvDto.fileName);

                    return Ok(contactRecords);
                }
                else
                {
                    return BadRequest();
                }            
        }
    }
}
