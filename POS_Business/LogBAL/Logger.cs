using POS_Business.Security;
using POS_DataAccess.LogDAL;
using System;

namespace POS_Business.LogBAL
{
    public static class Logger
    {
        public static void Initialize(string source = "POS_Log")
        {
            EventViewerLogger.Initialize(source);
        }

        // Every log message is written with the current username
        private static string Who
        {
            get { return Session.CurrentUser == null ? "-" : Session.CurrentUser.Username; }
        }

        public static void Info(string message) { EventViewerLogger.Info("[" + Who + "] " + message); }
        public static void Warn(string message) { EventViewerLogger.Warning("[" + Who + "] " + message); }
        public static void Error(string message, Exception ex) { EventViewerLogger.Error("[" + Who + "] " + message, ex); }
    }
}
