using TravisComms.Data.Repository.IdentityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TravisComms.Data.Repository.Interfaces
{
    public interface IIdentityRepository
    {
        Task<bool> FindUserByEmailAsync(string email);
        Task<MainUser> CreateNewUserAsync(MainUser newMainUser, string password, Guid accountHolderId);
        Task<string> GenerateEmailConfirmationCodeAsync(MainUser user);
    }
}
