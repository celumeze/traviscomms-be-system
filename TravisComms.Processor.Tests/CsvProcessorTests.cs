using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravisComms.CsvProcessing.Exceptions;
using TravisComms.CsvProcessing.Mapper;
using TravisComms.CsvProcessing.Processors;
using TravisComms.Data.Entities.Models;
using TravisComms.Processor.Tests.ExtTestData;
using Xunit;

namespace TravisComms.Processor.Tests
{
    public class CsvProcessorTests
    {

        [Theory]
        [MemberData(nameof(ContactsCsvTestData.ContactsTestCsv), MemberType = typeof(ContactsCsvTestData))]
        public async Task ContactsCsvParser_HaveContactsCsvFileUploaded_ShouldGetAllContactsFromFile(string fileName, int expectedNumOfRows, string delimiter)
        {
            //Arrrange
            ContactsCsvParser contactsCsvParser = new ContactsCsvParser();
            ContactHeader contactsHeader = new ContactHeader { contactNumberHeader = "contactNumber", firstNameHeader = "firstName", lastNameHeader = "lastName" };
            string separator = delimiter;
            Guid accountHolderId = Guid.NewGuid();

            //Act
            IEnumerable<dynamic> records = null;
            await using (var fileStream = new FileStream(fileName, FileMode.Open))
            {
                fileStream.Position = 0;
                records = contactsCsvParser.ParseContactsCsv(fileStream, separator, contactsHeader, accountHolderId);
            }

            //Assert
            records.Should().NotBeEmpty();
            records.Should().NotBeNull();
            records.Count().Should().Be(expectedNumOfRows-1);
        }

        [Theory]
        [MemberData(nameof(ContactsCsvTestData.ContactsTestWithoutNumberOfRows), MemberType = typeof(ContactsCsvTestData))]
        public async Task ContactsCsvParser_HaveContactsCsvFileUploaded_ShouldThrowExceptionWhenContactNumberHeaderNotInFile(string fileName, string delimiter)
        {
            //Arrrange
            ContactsCsvParser contactsCsvParser = new ContactsCsvParser();
            ContactHeader contactsHeader = new ContactHeader { contactNumberHeader = "wrongContactNumberHeader", firstNameHeader = "firstName", lastNameHeader = "lastName" };
            string separator = delimiter;
            Guid accountHolderId = Guid.NewGuid();

            //Act
            await using (var fileStream = new FileStream(fileName, FileMode.Open))
            {
                fileStream.Position = 0;
                Assert.Throws<ContactsCsvException>(() => contactsCsvParser.ParseContactsCsv(fileStream, separator, contactsHeader, accountHolderId));
            }
        }

    }
}
