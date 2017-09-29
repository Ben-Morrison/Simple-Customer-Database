using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerDatabase
{
    public enum LogType
    {
        Error,
        Warning,
        Event
    }

    public class Log
    {
        public static event EventHandler<EventArgs> NewLog;

        private static List<Log> Logs = new List<Log>();

        private LogType logType;
        private DateTime date;
        private string error;

        /// <summary>
        /// Logs an error with the date it occurred and the details of the error
        /// </summary>
        /// <param name="date">The date and time the error occurred</param>
        /// <param name="error">The details of the error</param>
        private Log(LogType logType, DateTime date, string error)
        {
            this.logType = logType;
            this.date = date;
            this.error = error;
        }

        /// <summary>
        /// The type of the Log entry
        /// </summary>
        public LogType LogType
        {
            get { return this.logType; }
            set { this.logType = value; }
        }

        /// <summary>
        /// The Date and Time the error occured
        /// </summary>
        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }

        /// <summary>
        /// The details of the error
        /// </summary>
        public string Error
        {
            get { return this.error; }
            set { this.error = value; }
        }

        /// <summary>
        /// Converts the Log object to a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string s = "";

            switch (this.logType)
            {
                case LogType.Error:
                    s += "Error: ";
                    break;
                case LogType.Warning:
                    s += "Warning: ";
                    break;
                case LogType.Event:
                    s += "Event: ";
                    break;
            }

            s += this.date.ToString();
            s += ", " + this.error;

            return s;
        }

        /// <summary>
        /// Returns a List of Log objects which each represent an error that has occurred
        /// </summary>
        /// <returns>A List of Log objects</returns>
        public static List<Log> GetLog()
        {
            return Log.Logs;
        }

        /// <summary>
        /// Adds an entry to the error log
        /// </summary>
        /// <param name="log">A Log object</param>
        public static void AddLog(Log log)
        {
            Log.Logs.Add(log);
            NewLog(null, new EventArgs());
        }

        /// <summary>
        /// Adds an entry to the error log
        /// </summary>
        /// <param name="time">The date and time the error occured</param>
        /// <param name="error">The details of the error</param>
        public static void AddLog(LogType logType, DateTime time, string error)
        {
            Log.Logs.Add(new Log(logType, time, error));
            NewLog(null, new EventArgs());
        }
    }
}
