using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlexiComms.Data.Tests
{
    internal class EfCoreLogger : ILogger
    {
        private readonly Action<string> _efCoreLogAction;
        private readonly LogLevel _logLevel;

        public EfCoreLogger(Action<string> efCoreLogAction, LogLevel logLevel)
        {
            _efCoreLogAction = efCoreLogAction;
            _logLevel = logLevel;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        //You want the parameter log level to log
        //if it meets loglevel condition
        public bool IsEnabled(LogLevel logLevel) 
        {
            return logLevel >= _logLevel;
        }

        //This is for when
        //you actually want to log something
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            _efCoreLogAction($"LogLevel: {logLevel}, {state}");
        }
    }
}
