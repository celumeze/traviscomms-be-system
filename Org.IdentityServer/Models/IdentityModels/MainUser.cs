using Microsoft.AspNetCore.Identity;
using System;

namespace Org.IdentityServer.Models
{
    public class MainUser : IdentityUser
    {
        public Guid AccountHolderId { get; set; }

    }
}
