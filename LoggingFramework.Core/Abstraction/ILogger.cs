using LoggingFramework.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingFramework.Core.Abstraction
{
    public interface ILogger
    {
        void Log(LogType type, string message, LogTarget target);

        ILoggerInstance LoggerInstance { get; set; }
    }
}
