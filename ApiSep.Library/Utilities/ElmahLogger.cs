using System;
using System.Web;
using ApiSep.Library.BaseClasses;
using ApiSep.Library.Handlers;
using Elmah;

namespace ApiSep.Library.Utilities
{
    public class ElmahLogger
    {
        public void LogException(Exception ex, RequestBase requestBase)
        {
            try
            {
                var context = HttpContext.Current;
                if (context == null)
                    return;
                var signal = ErrorSignal.FromContext(context);
                if (signal == null)
                    return;
                signal.Raise(ex);
            }
            catch (Exception ex)
            {
                ErrorHandler.LogException(ex);
            }
        }

        
        
    }
}
