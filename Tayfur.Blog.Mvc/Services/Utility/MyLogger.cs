using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tayfur.Blog.Mvc.Services.Utility
{
    public class MyLogger : ILogger
    {
        // singletton pattern : only one instance of this class
        // can be instanciated

        private static MyLogger instance;
        private static Logger logger; //static variable to hold a single instance
        // of the nlog logger

        private MyLogger()
        {

        }
        // create instance of the class if it has not yet been instanciated
        public static MyLogger GetInstance()
        {
            if (instance==null)
            {
                instance = new MyLogger();
            }
            return instance;
        }

        private Logger GetLogger(string theLogger)
        {
            if (MyLogger.logger==null)
            {
                MyLogger.logger = LogManager.GetLogger(theLogger);
            }
            return MyLogger.logger;
        }


        public void Debug(string message, string arg = null)
        {
            if (arg==null)
            {
                GetLogger("myLoggerRules").Debug(message);
            }
            else
            {
                GetLogger("myLoggerRules").Debug(message,arg);
            }
        }

        public void Error(string message, string arg = null)
        {
            if (arg == null)
            {
                GetLogger("myLoggerRules").Error(message);
            }
            else
            {
                GetLogger("myLoggerRules").Error(message, arg);
            }
        }

        public void Info(string message, string arg = null)
        {
            if (arg == null)
            {
                GetLogger("myLoggerRules").Info(message);
            }
            else
            {
                GetLogger("myLoggerRules").Info(message, arg);
            }
        }

        public void Warning(string message, string arg = null)
        {
            if (arg==null)
            {
                GetLogger("myLoggerRules").Warn(message);
            }
            else
            {
                GetLogger("myLoggerRules").Warn(message,arg);
            }
        }
    }
}