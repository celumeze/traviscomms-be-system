using System;
using System.ComponentModel.DataAnnotations;

namespace FlexiComms.Api.Dto
{
    public class ClientDto
    {       
        public Guid ClientId { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
        public string Company { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Active { get; set; }
        public Guid SubscriptionTypeId { get; set; }
        public Guid ClientRoleId { get; set; }
    }
}
