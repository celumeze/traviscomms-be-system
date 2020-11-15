using Org.IdentityServer.Models;
using System;
using System.Threading.Tasks;

namespace Org.IdentityServer.Interfaces
{
    public interface IIdentityRepository
    {
        Task<bool> FindUserByEmailAsync(string email);
        Task<MainUser> CreateNewUserAsync(MainUser newMainUser, string password, Guid accountHolderId);
        Task<string> GenerateEmailConfirmationCodeAsync(MainUser user);
    }
}
