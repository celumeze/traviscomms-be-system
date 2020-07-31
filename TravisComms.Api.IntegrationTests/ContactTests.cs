using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravisComms.Api.Controllers;
using TravisComms.Api.Dto;
using TravisComms.Data.Repository;
using Xunit;

namespace TravisComms.Api.IntegrationTests
{
    public class ContactTests : IntegrationBase
    {
        private readonly HttpClient _httpClient;

        public ContactTests(CustomWebApiFactory<Startup> factory) : base(factory)
        {
            _httpClient = GetFactory(true).CreateClient();
        }

        [Theory]
        [InlineData("POST")]
        public async Task ContactController_ContactAdded_ShouldReturnHttpStatus200(string method)
        {
            //Arrange            
            var newContact = new AddContactDto
            {
                AccountHolderId = Guid.Parse("CB0A792B-BF55-46B5-8795-10C43006BE92"),
                ContactNumber = "0901234569",
                FirstName = "Nonso",
                LastName = "Elumeze"
            };

            var request = new HttpRequestMessage(new HttpMethod(method), "api/contact");
            request.Content = new StringContent(JsonConvert.SerializeObject(newContact), Encoding.UTF8, "application/json");

            //Act
            var response = await _httpClient.SendAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
