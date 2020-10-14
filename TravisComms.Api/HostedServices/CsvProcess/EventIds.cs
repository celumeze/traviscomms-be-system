using Automatonymous;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravisComms.Api.HostedServices
{
    internal static class EventIds
    {
        public static readonly EventId ChannelMessageWritten = new EventId(100, "ChannelMesssageWritten");
    }
}
