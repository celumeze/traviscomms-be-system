using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravisComms.CsvProcessing.Interfaces;

namespace TravisComms.Api.HostedServices
{
    public class ContactsCsvProcessingService : BackgroundService
    {
        private readonly ILogger<ContactsCsvProcessingService> _logger;
        private readonly ContactsCsvParsingChannel _csvParsingChannel;
        private readonly IServiceProvider _serviceProvider;

        public ContactsCsvProcessingService(ILogger<ContactsCsvProcessingService> logger, ContactsCsvParsingChannel csvParsingChannel, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _csvParsingChannel = csvParsingChannel;
            _serviceProvider = serviceProvider;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await foreach(var contactCsvDetails in _csvParsingChannel.ReadAllAsync())
            {
                using var scope = _serviceProvider.CreateScope();

                var processor = scope.ServiceProvider.GetRequiredService<IContactsResultProcessor>();

                try
                {
                    await processor.ProcessAsync(contactCsvDetails.fileStream, contactCsvDetails.ContactHeader, contactCsvDetails.separatorText, contactCsvDetails.accountHolderId, contactCsvDetails.fileName);
                }
                finally
                {
                    File.Delete(contactCsvDetails.fileName);
                }
            }
        }
    }
}
