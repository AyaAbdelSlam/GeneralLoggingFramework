using LoggingFramework.Common.Helpers;
using LoggingFramework.Entities;
using LoggingFramework.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingFramework.Core.Abstraction
{
    public interface ILoggerInstance
    {
        ILogItem LogItem { get; set; }
        void Log();
    }
}
