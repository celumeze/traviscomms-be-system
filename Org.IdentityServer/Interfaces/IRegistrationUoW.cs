using System;

namespace Org.IdentityServer.Interfaces
{
    public interface IRegistrationUoW
    {
        IIdentityRepository IdentityRepository { get; }
        IAccountHolderRepository AccountHolderRepository { get; }
        IAccountHolderRoleRepository AccountHolderRoleRepository { get; }
    }
}
