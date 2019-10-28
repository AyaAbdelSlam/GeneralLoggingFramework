using LoggingFramework.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingFramework.Entities.Abstraction
{
    public interface ILogItem
    {
        Guid Id { get; set; }
        string Message { get; set; }

        DateTime TimeStamp { get; set; }

        LogType Type { get; set; }
    }
}
