using LoggingFramework.Common.Helpers;
using LoggingFramework.Core.Abstraction;
using LoggingFramework.Entities;
using System;

namespace LoggingFramework.Core
{
    public class Logger : ILogger
    {
        protected static Logger instance = null;
        protected static readonly object padlock = new object();

        public ILoggerInstance LoggerInstance { get; set; }

        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new Logger();
                        }
                    }
                }
                return instance;
            }
        }

        private void CreateInstance(LogTarget target, LogItem item)
        {
            switch (target)
            {
                case LogTarget.Console:
                    LoggerInstance = ConsoleLoggerInstance.Instance;
                    LoggerInstance.LogItem = item;
                    break;

                case LogTarget.File:
                    LoggerInstance = FileLoggerInstance.Instance;
                    LoggerInstance.LogItem = item;
                    break;
            }
        }

        public void Log(LogType type, string message, LogTarget target)
        {
            CreateInstance(target, new LogItem()
            {
                Id = Guid.NewGuid(),
                Message = message,
                Type = type,
                TimeStamp = DateTime.Now
            });

            LoggerInstance.Log();
        }
    }
}

