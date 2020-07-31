using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using TravisComms.Data.Repository.IdentityModels;
using TravisComms.Data.Repository.Interfaces;
using TravisComms.Data.Repository.Repository;

namespace TravisComms.Data.Repository.UoW
{
    public class RegistrationUoW : IRegistrationUoW
    {
        private readonly TravisCommsSqlDbContext _TravisCommsSqlDbContext;
        private readonly UserManager<MainUser> _UserManager;
        public RegistrationUoW(TravisCommsSqlDbContext TravisCommsSqlDbContext, UserManager<MainUser> UserManager) 
        {
            _TravisCommsSqlDbContext = TravisCommsSqlDbContext;
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
                    _accountHolderRepository = new AccountHolderRepository(_TravisCommsSqlDbContext);
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
                    _accountHolderRoleRepository = new AccountHolderRoleRepository(_TravisCommsSqlDbContext);
                }
                return _accountHolderRoleRepository;
            }
        }
    }
}
