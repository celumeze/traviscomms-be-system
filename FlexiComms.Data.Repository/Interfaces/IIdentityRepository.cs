using FlexiComms.Data.Repository.IdentityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlexiComms.Data.Repository.Interfaces
{
    public interface IIdentityRepository
    {
        Task<bool> FindUserByEmailAsync(string email);
        Task<bool> CreateNewUser(MainUser newMainUser, string password);
        Task<bool> CreateNewUserRole(MainUser newUser);
    }
}
