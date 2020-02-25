using FlexiComms.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FlexiComms.Data.Tests.Registration
{
    public class ClientRepoTests
    {
        [Fact]
        public void GetClients_Client_ClientIsRetrieved()
        {
            //arrange
            var options = new DbContextOptionsBuilder<FlexiCommsSqlDbContext>()
                          .UseInMemoryDatabase("FlexiCommsDatabaseForTesting")
                          .Options;
            using (var context = new FlexiCommsNoSqlDbContext(options))
            {

            }
        }
    }
}
