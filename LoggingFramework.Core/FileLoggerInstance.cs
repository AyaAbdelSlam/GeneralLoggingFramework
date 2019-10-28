using LoggingFramework.Core.Abstraction;
using LoggingFramework.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LoggingFramework.Core
{
    public class FileLoggerInstance : ILoggerInstance
    {
        private static FileLoggerInstance instance = null;
        private static readonly object padlock = new object();
        private string _docPath;
        
        public static FileLoggerInstance Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new FileLoggerInstance();
                        }
                    }
                }
                return instance;
            }
        }

        public ILogItem LogItem { get; set; }

        public void Log()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Append text to an existing file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "LoggerResults.txt"), true))
            {
                outputFile.WriteLine($"{LogItem.Type.ToString()}: {LogItem.Message} :{LogItem.TimeStamp}");
            }
        }
    }
}
