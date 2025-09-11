using System;
using System.Diagnostics;

namespace DVLD_DataAccess
{
    public class clsEventLog
    {
        private string _LogName;
        private string _SourceName = "DVLD_App";

        public clsEventLog(string logName)
        {
            this._LogName = logName;

        }


        public void AddEventLog(Exception ex, EventLogEntryType eventLogEntryType)
        {
            // Create the event source if it does not exist
            if (!EventLog.SourceExists(_SourceName))
            {
                EventLog.CreateEventSource(_SourceName, _LogName);
            }
            EventLog.WriteEntry(_LogName, ex.Message, eventLogEntryType);
        }


    }
}
