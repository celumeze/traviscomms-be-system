using FluentAssertions;
using MassTransit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravisComms.Api.Dto;
using TravisComms.Data.Repository;
using TravisComms.Data.Repository.IdentityModels;
using Xunit;

namespace TravisComms.Api.IntegrationTests
{
    public class RegistrationTests : IClassFixture<CustomWebApiFactory<TravisComms.Api.Startup>>
    {
        private readonly HttpClient _httpClient;
        private readonly CustomWebApiFactory<TravisComms.Api.Startup> _factory;

        public RegistrationTests(CustomWebApiFactory<TravisComms.Api.Startup> factory)
        {
            _factory = factory;
            var config = new ConfigurationBuilder()
                            .AddUserSecrets<Startup>()
                            .Build();

            var hostBuilder = new WebHostBuilder()
                                  .UseConfiguration(config)
                                  .UseStartup<Startup>();
            var testServer = new TestServer(hostBuilder);
             
            _httpClient = _factory.CreateClient();
            
            
        }

        [Theory]
        [InlineData("POST")]
        public async Task RegisterController_AccountHolderAdded_ShouldReturnHttpStatus200(string method)
        {
            //Arrange
            var addAccountHolderDto = new AddAccountHolderDto
            {
                EmailAddress = "joebloggs@gmail.com",
                Password = "P@ssw0rd1",
                ConfirmPassword = "P@ssw0rd1",
                Company = "jsjds",
                FirstName = "Joe",
                LastName = "Bloggs",
                Active = true,
                SubscriptionTypeId = Guid.Parse("360CF2ED-3705-4248-A4A4-B15C8A3077DE"),
                AccountHolderRoleId = Guid.Empty

            };
            var request = new HttpRequestMessage(new HttpMethod(method), "api/register");
            request.Content = new StringContent(JsonConvert.SerializeObject(addAccountHolderDto), Encoding.UTF8, "application/json");

            //Act
            var response = await _httpClient.SendAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
