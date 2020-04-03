using FlexiComms.Data.Repository;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace FlexiComms.Data.Tests.Registration
{
    public class ClientRepoTests
    {
        private readonly ITestOutputHelper _output;

        public ClientRepoTests(ITestOutputHelper output)
        {
            _output = output;
        }
        [Fact]
        public void GetClients_Client_ClientIsRetrieved()
        {
            //var logs = new List<string>();
            //arrange
            //var options = new DbContextOptionsBuilder<FlexiCommsSqlDbContext>()
            //              .UseInMemoryDatabase("FlexiCommsDatabaseForTesting")
            //              .Options;
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory" };
            var connection = new SqliteConnection(connectionStringBuilder.ToString());
            var options = new DbContextOptionsBuilder<FlexiCommsSqlDbContext>()
                              .UseLoggerFactory(new LoggerFactory(new[] 
                              { 
                                 new LogToActionLoggerProvider((log)=> 
                                 {
                                     //logs.Add(log);
                                     //output to test explorer
                                     _output.WriteLine(log);
                                 })
                              }))
                              .UseSqlite(connection)
                              .Options;
            //using (var context = new FlexiCommsNoSqlDbContext(options))
            //{
            //    context.Database.OpenConnection();
            //    context.Database.EnsureCreated();
            //}
        }
    }
}
