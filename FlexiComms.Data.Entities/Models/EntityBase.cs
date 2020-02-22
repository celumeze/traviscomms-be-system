using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FlexiComms.Data.Entities.Models
{
    public class EntityBase
    {

        [Required]
        public DateTime DateCreated { get; set; } = DateTime.Now;
        [MaxLength(50)]
        public string CreatedBy { get; set; } = "FlexiComms\\System";

        public DateTime? DateModified { get; set; }
        [MaxLength(50)]
        public string ModifiedBy { get; set; }
    }
}
