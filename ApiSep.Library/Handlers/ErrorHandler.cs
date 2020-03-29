using System;
using ApiSep.ErrorLogger.Services.Logging;

namespace ApiSep.Library.Handlers
{
    public static class ErrorHandler
    {
        public static void LogException(Exception e)
        {
            LogFactory.Logger().Error(e);
        }

        public static void LogMessage(string message)
        {
            LogFactory.Logger().Info(message);
        }
    }
}