using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using TravisComms.Api.Dto;

namespace TravisComms.Api.HostedServices
{
    public class ContactsCsvParsingChannel
    {
        private const int MaxMessagesInChannel = 100;

        private readonly Channel<ContactsCsvDto> _channel;
        private readonly ILogger<ContactsCsvParsingChannel> _logger;

        public ContactsCsvParsingChannel(ILogger<ContactsCsvParsingChannel> logger)
        {
            var options = new BoundedChannelOptions(MaxMessagesInChannel)
            {
                SingleWriter = false,
                SingleReader = true
            };
            _channel = Channel.CreateBounded<ContactsCsvDto>(options);
            _logger = logger;
        }

        public async Task<bool> AddContactsCsvDetailsAsync(ContactsCsvDto contactsCsvDto, CancellationToken cancellationToken = default)
        {
            while(await _channel.Writer.WaitToWriteAsync(cancellationToken) && !cancellationToken.IsCancellationRequested)
            {
                if(_channel.Writer.TryWrite(contactsCsvDto))
                {
                    Log.ChannelMessageWritten(_logger, contactsCsvDto);
                    return true;
                }
            }
            return false;
        }

        public IAsyncEnumerable<ContactsCsvDto> ReadAllAsync(CancellationToken cancellationToken = default) => _channel.Reader.ReadAllAsync(cancellationToken);
    }
}
