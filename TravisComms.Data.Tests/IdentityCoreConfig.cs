using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TravisComms.Data.Repository;
using TravisComms.Data.Repository.IdentityModels;

namespace TravisComms.Data.Tests
{
    public static class IdentityCoreConfig
    {
        public static UserManager<MainUser> ConfigureUserManager(Mock<IOptions<IdentityOptions>> optionsAccessor, Mock<IUserValidator<MainUser>> userValidator,
                                                                    Mock<ILogger<UserManager<MainUser>>> _logger, IUserStore<MainUser> store = null)
        {
            store = store ?? new Mock<IUserStore<MainUser>>().Object;

            optionsAccessor = new Mock<IOptions<IdentityOptions>>();
            var idOptions = new IdentityOptions();
            idOptions.Lockout.AllowedForNewUsers = false;
            optionsAccessor.Setup(o => o.Value).Returns(idOptions);

            var passwordHasher = new PasswordHasher<MainUser>();
            userValidator = new Mock<IUserValidator<MainUser>>();
            var _userValidators = new List<IUserValidator<MainUser>>();
            _userValidators.Add(userValidator.Object);

            var _pwdValidators = new List<PasswordValidator<MainUser>>();
            _pwdValidators.Add(new PasswordValidator<MainUser>());

            var _keyNormalizer = new UpperInvariantLookupNormalizer();
            var _identityErrorDescriber = new IdentityErrorDescriber();

            _logger = new Mock<ILogger<UserManager<MainUser>>>();
            var userManager = new UserManager<MainUser>(store, optionsAccessor.Object, passwordHasher, _userValidators,
                                                      _pwdValidators, _keyNormalizer, 
                                                      _identityErrorDescriber, null, _logger.Object);

            userValidator.Setup(v => v.ValidateAsync(userManager, It.IsAny<MainUser>()))
           .Returns(Task.FromResult(IdentityResult.Success)).Verifiable();
            return userManager;
        }
    }
}
