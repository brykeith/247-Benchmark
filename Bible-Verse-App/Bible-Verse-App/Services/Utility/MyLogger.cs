using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bible_Verse_App.Services.Utility
{
    public class MyLogger : ILogger
    {

        // singleton pattern. Only one instance of this class can be instanciated
        private static MyLogger instance; // singleton design pattern, single instance of class
        private static Logger logger; // static variable to hold a single instance of the nLog logger

        // single design pattern - private constructor
        private MyLogger()
        {

        }

        /* 
         * single design pattern shown here - this function creates an instance of the class
         * if it has not yet been instanciated. If the class already exists, then return 
         * a reference to the original
        */
        public static MyLogger GetInstance()
        {
            if (instance == null)
                instance = new MyLogger();
            
            return instance;
        }

        // meant for internal use only. Used to access the logger
        private Logger GetLogger(string theLogger)
        {
            if (MyLogger.logger == null)
                MyLogger.logger = LogManager.GetLogger(theLogger);

            return MyLogger.logger;
        }





        // Debug method for our logger
        public void Debug(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("myAppLoggerRules").Debug(message);
            else
                GetLogger("myAppLoggerRules").Debug(message, arg);
        }

        // Error method for our logger
        public void Error(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("myAppLoggerRules").Error(message);
            else
                GetLogger("myAppLoggerRules").Error(message, arg);
        }

        // Info method for our logger
        public void Info(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("myAppLoggerRules").Info(message);
            else
                GetLogger("myAppLoggerRules").Info(message, arg);
        }

        // Warning method for our logger
        public void Warning(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("myAppLoggerRules").Warn(message);
            else
                GetLogger("myAppLoggerRules").Warn(message, arg);
        }
    }
}