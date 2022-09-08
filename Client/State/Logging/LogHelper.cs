using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.CompilerServices;
using log4net;

namespace Client.State.Logging
{
    public static class LogHelper
    {
        public static ILog GetLogger([CallerFilePath] string filename = "")
        {
            return LogManager.GetLogger(filename);
        }


        public static void GetLogs(ObservableCollection<string> collection)
        {
            string solutionPath = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("bin", StringComparison.Ordinal));

            IEnumerable<string> logs = File.ReadAllLines(solutionPath + "log-file.txt");

            collection.Clear();

            foreach (string log in logs)
            {
                collection.Add(log);
            }
        }
    }
}
