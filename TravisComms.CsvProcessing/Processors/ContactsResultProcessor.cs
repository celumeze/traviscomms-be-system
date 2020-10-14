using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravisComms.CsvProcessing.Exceptions;
using TravisComms.CsvProcessing.Interfaces;
using TravisComms.CsvProcessing.Mapper;
using TravisComms.Data.Repository.Interfaces;

namespace TravisComms.CsvProcessing.Processors
{
    public class ContactsResultProcessor : IContactsResultProcessor
    {
        private readonly IContactsCsvParser _contactsCsvParser;
        private readonly IContactRepository _contactRepository;
        private readonly ILogger<ContactsResultProcessor> _logger;

        public ContactsResultProcessor(IContactsCsvParser contactsCsvParser, 
                                       IContactRepository contactRepository, 
                                       ILogger<ContactsResultProcessor> logger)
        {
            _contactsCsvParser = contactsCsvParser;
            _contactRepository = contactRepository;
            _logger = logger;
        }


        public async Task ProcessAsync(FileStream fileStream, ContactHeader contactHeader, string separator, 
                                       Guid accountHolderId, string filePath, CancellationToken cancellationToken = default)
        {
           
            var contactsResult = _contactsCsvParser.ParseContactsCsv(fileStream, separator, contactHeader, accountHolderId);

            _logger.LogInformation($"Processed contacts from csv file.");

            //After this point, results of contacts will be
            //posted even cancellation have been signalled
            //so that result for part of the file is not sent
            cancellationToken.ThrowIfCancellationRequested();

            await _contactRepository.AddBatchContactDetails(contactsResult, accountHolderId);
        }

        public async Task<dynamic>  UploadAsync(FileStream fileStream, ContactHeader contactHeader, string separator, Guid accountHolderId, string filePath, CancellationToken cancellationToken = default)
        {
            var contactsResult = _contactsCsvParser.ParseContactsCsv(fileStream, separator, contactHeader, accountHolderId);

            _logger.LogInformation($"Processed contacts from csv file.");

            //After this point, results of contacts will be
            //posted even cancellation have been signalled
            //so that result for part of the file is not sent
            cancellationToken.ThrowIfCancellationRequested();

            return await _contactRepository.AddBatchContactDetails(contactsResult, accountHolderId);
        }
    }
}
