using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravisComms.Data.Tests
{
    //LoggerProvider is responsible for
    //creating the actual logger (EFCoreLogger)
    internal class LogToActionLoggerProvider : ILoggerProvider
    {
        private readonly Action<string> _efCoreLogAction;
        private readonly LogLevel _logLevel;

        public LogToActionLoggerProvider(Action<string> efCoreLogAction, LogLevel logLevel = LogLevel.Information)
        {
            _efCoreLogAction = efCoreLogAction;
            _logLevel = logLevel;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new EfCoreLogger(_efCoreLogAction, _logLevel);
        }

        public void Dispose() 
        {
            //nothing to be disposed
        }
    }
}
