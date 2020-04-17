using TravisComms.Data.Entities.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TravisComms.Data.Repository.IdentityModels
{
    public class MainRole : IdentityRole
    {
        public Guid ClientRoleId { get; set; }
        [Required]
        public DateTime DateCreated { get; set; } = DateTime.Now;
        [MaxLength(50)]
        public string CreatedBy { get; set; } = "TravisComms\\System";

        public DateTime? DateModified { get; set; }
        [MaxLength(50)]
        public string ModifiedBy { get; set; }

    }
}
