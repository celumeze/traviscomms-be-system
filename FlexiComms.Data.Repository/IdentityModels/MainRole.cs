using FlexiComms.Data.Entities.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlexiComms.Data.Repository.IdentityModels
{
    public class MainRole : IdentityRole
    {
        public Guid ClientRoleId { get; set; }

    }
}
