using TravisComms.Data.Entities.Enums;
using TravisComms.Data.Repository.IdentityModels;
using TravisComms.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;

namespace TravisComms.Data.Repository.Repository
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly UserManager<MainUser> _userManager;

        public IdentityRepository(UserManager<MainUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<MainUser> CreateNewUserAsync(MainUser newMainUser, string password, Guid accountHolderId)
        {
            newMainUser.AccountHolderId = accountHolderId;
            var userResult = await _userManager.CreateAsync(newMainUser, password);
            var roleResult = await _userManager.AddToRoleAsync(newMainUser, Enum.GetName(typeof(RoleType), RoleType.AdminRoleType)
                                                                    .Replace(nameof(RoleType), ""));
           
            if(userResult.Succeeded && roleResult.Succeeded)
            {
                return newMainUser;
            }
            return null;
        }

        public async Task<bool> FindUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }

        public async Task<string> GenerateEmailConfirmationCodeAsync(MainUser user)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            return code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));            
        }
    }
}
