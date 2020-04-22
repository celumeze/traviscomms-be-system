using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravisComms.Api.Dto
{
    public class AddAccountHolderDto
    {

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
        public string Company { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Active { get; set; }
        public bool IsUpgradedToPaid { get; set; }
        public DateTime? DateOfUpgrade { get; set; }
        public Guid SubscriptionTypeId { get; set; }
        public Guid AccountHolderRoleId { get; set; }
    }
}
