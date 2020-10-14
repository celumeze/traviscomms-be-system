using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravisComms.CsvProcessing.Mapper
{
    public class ContactHeader
    {
        public string firstNameHeader { get; set; }
        public string lastNameHeader { get; set; }
        [Required]
        public string contactNumberHeader { get; set; }
    }
}
