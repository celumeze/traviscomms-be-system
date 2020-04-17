using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravisComms.Data.Entities.Models
{
    public class EntityBase
    {

        [Required]
        public DateTime DateCreated { get; set; } = DateTime.Now;
        [MaxLength(50)]
        public string CreatedBy { get; set; } = "TravisComms\\System";

        public DateTime? DateModified { get; set; } 
        [MaxLength(50)]
        public string ModifiedBy { get; set; }
    }
}
