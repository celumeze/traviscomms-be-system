using FluentAssertions;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Azure.Cosmos;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravisComms.Data.Repository;
using TravisComms.Data.Repository.IdentityModels;
using TravisComms.Data.Repository.Interfaces;
using TravisComms.Data.Repository.Repository;
using Xunit;

namespace TravisComms.Data.Tests.Identity
{
    public class IdentityRepoTests
    {       
        private  Mock<IOptions<IdentityOptions>> _optionsAccessor;
        private  Mock<IUserValidator<MainUser>> _userValidator;   
        private  Mock<ILogger<UserManager<MainUser>>> _logger;

        public IdentityRepoTests()
        {
            _optionsAccessor = new Mock<IOptions<IdentityOptions>>();
            _userValidator = new Mock<IUserValidator<MainUser>>();
            _logger = new Mock<ILogger<UserManager<MainUser>>>();
        }

        [Fact]
        public async Task CreateNewUser_NewAccountHolderAsUser_ShouldAddUserAndRoleAsAdmin()
        {
            //Arrange       
            var options = new DbContextOptionsBuilder<TravisCommsSqlDbContext>()
                              .UseInMemoryDatabase($"TravisCommsTestingDb{Guid.NewGuid()}")
                              .Options;

            using (TravisCommsSqlDbContext context = new TravisCommsSqlDbContext(options))
            {
                var mainRole = new MainRole
                {
                    Id = "833583c3-1d58-4b95-baad-05b35acdd6a3",
                    ConcurrencyStamp = "ef51e739-98e5-4455-9ae0-061ebfdda460",
                    NormalizedName = "ADMIN",
                    AccountHolderRoleId = Guid.Parse("CB0A792B-BF55-46B5-8795-10C43006BE92"),
                    Name = "Admin",
                    DateCreated = DateTime.ParseExact("17/04/2020 18:15:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("en-gb")),
                    CreatedBy = "TravisComms\\System"

                };
                context.Roles.Add(mainRole);
                context.SaveChanges();
            }

            using (TravisCommsSqlDbContext context = new TravisCommsSqlDbContext(options))
            { 
                var accountHolderId = Guid.Parse("0adc301a-24cf-47ba-9b0e-202fc3abb7d7");
                var password = "P@ssw0rd1";
                var mainUser = new MainUser
                {
                    Id = "0adc301a-24cf-47ba-9b0e-202fc3abb7d7",
                    Email = "joebloggs@gmail.com",
                    UserName = "joebloggs@gmail.com"
                };


                var userStore = new UserStore<MainUser, MainRole, TravisCommsSqlDbContext>(context);
                var userManager = IdentityCoreConfig.ConfigureUserManager(_optionsAccessor, _userValidator, _logger, userStore);


                var objectUnderTest = new IdentityRepository(userManager);

                //Act
                var result = await objectUnderTest.CreateNewUserAsync(mainUser, password, accountHolderId);
                var userRole = await context.UserRoles.FirstOrDefaultAsync();

                //Assert
                result.Email.Should().Be("joebloggs@gmail.com");
                result.UserName.Should().Be("joebloggs@gmail.com");
                userRole.RoleId.Should().Be("833583c3-1d58-4b95-baad-05b35acdd6a3");
            }
            
        }

              
    }
}
