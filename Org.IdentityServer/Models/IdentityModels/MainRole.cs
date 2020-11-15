using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Org.IdentityServer.Models
{
    public class MainRole : IdentityRole
    {
        public Guid AccountHolderRoleId { get; set; }
        [Required]
        public DateTime DateCreated { get; set; } = DateTime.Now;
        [MaxLength(50)]
        public string CreatedBy { get; set; } = "TravisComms\\System";

        public DateTime? DateModified { get; set; }
        [MaxLength(50)]
        public string ModifiedBy { get; set; }

    }
}
