using System;
using System.IO;

namespace POS_DataAccess.LogDAL
{
    internal static class FileLogger
    {
        private static readonly object _lock = new object();

        public static void Write(string level, string message)
        {
            try
            {
                var dir = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "POS", "Logs");
                lock (_lock)
                {
                    Directory.CreateDirectory(dir);
                    var file = Path.Combine(dir, DateTime.Now.ToString("yyyy-MM-dd") + ".log");
                    File.AppendAllText(file,
                        DateTime.Now.ToString("HH:mm:ss") + " [" + level + "] " + message + Environment.NewLine);
                }
            }
            catch
            {
            }

        }

    }
}
