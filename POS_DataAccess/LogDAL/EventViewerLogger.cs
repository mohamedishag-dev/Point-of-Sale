using System;
using System.Diagnostics;

namespace POS_DataAccess.LogDAL
{
    public static class EventViewerLogger
    {
        private static string _source = "POS_Log";
        private static bool _ready;

        public static void Initialize(string source)
        {
            _source = source;
            try
            {
                if (!EventLog.SourceExists(_source))
                    EventLog.CreateEventSource(_source, "Application");
                _ready = true;
            }
            catch (Exception ex)
            {
                _ready = false;
                FileLogger.Write("Warning", "تعذر تهيئة Event Viewer، سيتم الحفظ في ملف: " + ex.Message);
            }
        }

        public static void Error(string message, Exception ex)
        {
            Write(message + ": " + (ex == null ? "" : ex.ToString()), EventLogEntryType.Error);
        }
        private static void Write(string message, EventLogEntryType type)
        {
            if (message == null) message = "";
            if (message.Length > 30000) message = message.Substring(0, 30000);

            try
            {
                if (_ready)
                {
                    EventLog.WriteEntry(_source, message, type);
                    return;
                }
            }
            catch
            {
            }

            FileLogger.Write(type.ToString(), message);
        }
        public static void Warning(string message) { Write(message, EventLogEntryType.Warning); }
        public static void Info(string message) { Write(message, EventLogEntryType.Information); }

    }

}
