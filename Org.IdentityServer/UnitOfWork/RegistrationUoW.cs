using Microsoft.AspNetCore.Identity;
using Org.IdentityServer.Data;
using Org.IdentityServer.Interfaces;
using Org.IdentityServer.Models;
using Org.IdentityServer.Repository;
using System;

namespace Org.IdentityServer.UnitOfWork
{
    public class RegistrationUoW : IRegistrationUoW
    {
        private readonly TravisCommsIdentityDbContext _TravisCommsIdDbContext;
        private readonly UserManager<MainUser> _UserManager;
        public RegistrationUoW(TravisCommsIdentityDbContext TravisCommsIdDbContext, UserManager<MainUser> UserManager) 
        {
            _TravisCommsIdDbContext = TravisCommsIdDbContext;
            _UserManager = UserManager;

        }

        private IIdentityRepository _identityRepository;
        public IIdentityRepository IdentityRepository
        {
            get
            {
                if (_identityRepository == null)
                {
                    _identityRepository = new IdentityRepository(_UserManager);
                }
                return _identityRepository;
            }
        }

        private IAccountHolderRepository _accountHolderRepository;
        public IAccountHolderRepository AccountHolderRepository
        {
            get
            {
                if (_accountHolderRepository == null)
                {
                    _accountHolderRepository = new AccountHolderRepository(_TravisCommsIdDbContext);
                }
                return _accountHolderRepository;
            }
        }

        private IAccountHolderRoleRepository _accountHolderRoleRepository;
        public IAccountHolderRoleRepository AccountHolderRoleRepository
        {
            get
            {
                if (_accountHolderRoleRepository == null)
                {
                    _accountHolderRoleRepository = new AccountHolderRoleRepository(_TravisCommsIdDbContext);
                }
                return _accountHolderRoleRepository;
            }
        }
    }
}
