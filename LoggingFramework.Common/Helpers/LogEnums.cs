using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingFramework.Common.Helpers
{
    public enum LogType:int
    {
        Error,
        Information,
        Warning,
        Fatal,
        Debug,
        Trace
    }
    public enum LogTarget:int
    {
        Database,
        File,
        Console
    }
}
