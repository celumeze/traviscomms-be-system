using TravisComms.Data.Entities.Enums;
using TravisComms.Data.Repository.IdentityModels;
using TravisComms.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TravisComms.Data.Repository.Repository
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly UserManager<MainUser> _userManager;

        public IdentityRepository(UserManager<MainUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> CreateNewUser(MainUser newMainUser, string password)
        {
            var result = await _userManager.CreateAsync(newMainUser, password);
            return result.Succeeded;
        }

        public async Task<bool> CreateNewUserRole(MainUser newUser)
        {
            var result = await _userManager.AddToRoleAsync(newUser, Enum.GetName(typeof(RoleType), RoleType.AdminRoleType));
            return result.Succeeded;
        }

        public async Task<bool> FindUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }
    }
}
