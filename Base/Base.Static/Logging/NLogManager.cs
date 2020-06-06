using System;
using System.Diagnostics;
using Base.Static.Application;
using NLog;
using NLog.Web;

namespace Base.Static.Logging
{
    public class NLogManager
    {
        private static readonly LogFactory logFactory =
            NLogBuilder.ConfigureNLog(AppSettings.Get<string>("Logging:ConfigFile"));

        public static Logger GetCurrentClassLogger()
        {
            try
            {
                var method = new StackFrame(1).GetMethod();
                return GetLogger(method.DeclaringType.Name);
            }
            catch (Exception e)
            {
                var logger = logFactory.GetLogger("common");
                return logger;
            }
        }

        public static Logger GetLogger(string name)
        {
            var logger = logFactory.GetLogger(name);
            return logger;
        }
    }
}