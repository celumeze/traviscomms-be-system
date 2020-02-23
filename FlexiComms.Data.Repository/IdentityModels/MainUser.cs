using FlexiComms.Data.Entities.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlexiComms.Data.Repository.IdentityModels
{
    public class MainUser : IdentityUser
    {
        public Guid ClientId { get; set; }

    }
}
