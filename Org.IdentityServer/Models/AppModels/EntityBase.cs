using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Org.IdentityServer.Models
{
    public class EntityBase
    {

        [Required]
        public DateTime DateCreated { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? DateModified { get; set; } 
        [MaxLength(50)]
        public string ModifiedBy { get; set; }
    }
}
