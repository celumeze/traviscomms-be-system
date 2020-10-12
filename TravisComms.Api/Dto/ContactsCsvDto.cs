using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TravisComms.CsvProcessing.Mapper;

namespace TravisComms.Api.Dto
{
    public class ContactsCsvDto
    {
        [NotMapped]
        public ContactHeader ContactHeader { get; set; }
        public string separatorText { get; set; }
        public IFormFile file { get; set; }
        public string fileName { get; set; }
        [NotMapped]
        public FileStream fileStream { get; set; }
        public Guid accountHolderId { get; set; }
    }
}
