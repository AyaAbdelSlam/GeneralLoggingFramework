using LoggingFramework.Common.Helpers;
using LoggingFramework.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingFramework.Entities
{
    public class LogItem : ILogItem
    {
        public Guid Id { get; set; }

        public string Message { get; set; }

        public DateTime TimeStamp { get; set; }

        public LogType Type { get; set; }
    }
}
