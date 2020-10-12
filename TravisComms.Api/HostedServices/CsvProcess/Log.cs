using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravisComms.Api.Dto;

namespace TravisComms.Api.HostedServices
{
    public static class Log
    {
        private static readonly Action<ILogger, ContactsCsvDto, Exception> _channelMessageWritten = LoggerMessage.Define<ContactsCsvDto>(
            LogLevel.Information,
            EventIds.ChannelMessageWritten,
            "Contacts list {FileName} was written to the channel");

        public static void ChannelMessageWritten(ILogger logger, ContactsCsvDto contactsCsvDto)
        {
            _channelMessageWritten(logger, contactsCsvDto, null);
        }
    }
}
