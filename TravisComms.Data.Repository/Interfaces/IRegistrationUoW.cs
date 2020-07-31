using System;
using System.Collections.Generic;
using System.Text;

namespace TravisComms.Data.Repository.Interfaces
{
    public interface IRegistrationUoW
    {
        IIdentityRepository IdentityRepository { get; }
        IAccountHolderRepository AccountHolderRepository { get; }
        IAccountHolderRoleRepository AccountHolderRoleRepository { get; }
    }
}
