﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravisComms.Api.Dto
{
    public class AddContactDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [MaxLength(20)]
        [Range(0, long.MaxValue, ErrorMessage = "Contact Number can only contain numbers")]
        public string ContactNumber { get; set; }
        public Guid AccountHolderId { get; set; }
    }
}
