using LoggingFramework.Common.Helpers;
using LoggingFramework.Core.Abstraction;
using LoggingFramework.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingFramework.Core
{
    public class ConsoleLoggerInstance : ILoggerInstance
    {
        private static ConsoleLoggerInstance instance = null;
        private static readonly object padlock = new object();

        public static ConsoleLoggerInstance Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new ConsoleLoggerInstance();
                        }
                    }
                }
                return instance;
            }
        }

        public ILogItem LogItem { get; set; }

        private ConsoleColor _color;
        
        //public ConsoleLoggerInstance(ILogItem item)
        //{
        //    LogItem = item;
        //}

        public void Log()
        {
            SettingForeColorBasedOnLogType(LogItem.Type);
            Console.WriteLine($"{LogItem.Type.ToString()}: {LogItem.Message} :{LogItem.TimeStamp}");
        }

        private void SettingForeColorBasedOnLogType(LogType type)
        {
            switch (type)
            {
                case LogType.Trace:
                    _color = ConsoleColor.DarkBlue;
                    break;
                case LogType.Warning:
                    _color = ConsoleColor.DarkYellow;

                    break;
                case LogType.Debug:
                    _color = ConsoleColor.DarkCyan;

                    break;
                case LogType.Error:
                    _color = ConsoleColor.Red;

                    break;
                case LogType.Fatal:
                    _color = ConsoleColor.DarkRed;

                    break;
                case LogType.Information:
                    _color = ConsoleColor.DarkGray;

                    break;

                default:
                    _color = ConsoleColor.White;
                    break;
            }
        }
    }
}
