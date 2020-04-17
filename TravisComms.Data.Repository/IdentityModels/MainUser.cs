using TravisComms.Data.Entities.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravisComms.Data.Repository.IdentityModels
{
    public class MainUser : IdentityUser
    {
        public Guid ClientId { get; set; }

    }
}
