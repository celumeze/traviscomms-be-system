using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravisComms.Api.Dto
{
    public class ContactDto
    {
        [Required]
        public Guid Id { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(20)]
        public string ContactNumber { get; set; }
        public Guid AccountHolderId { get; set; }     
    }
}
