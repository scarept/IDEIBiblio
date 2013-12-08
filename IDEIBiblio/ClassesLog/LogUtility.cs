using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IDEIBiblio.ClassesLog
{
    public class LogUtility
    {
        public static string TrataException(Exception x)
        {
            Exception logException = x;
            if (x.InnerException != null) logException = x.InnerException;

            string strErrorMsg = Environment.NewLine + "Erro no URL:\t" + System.Web.HttpContext.Current.Request.Path;

            strErrorMsg += Environment.NewLine + "URL Completo:\t" + System.Web.HttpContext.Current.Request.RawUrl;

            strErrorMsg += Environment.NewLine + "Mensagem:\t" + logException.Message;

            strErrorMsg += Environment.NewLine + "Origem:\t" + logException.Source;

            strErrorMsg += Environment.NewLine + "Stack Trace:\t" + logException.StackTrace;

            strErrorMsg += Environment.NewLine + "URL destino:\t" + logException.TargetSite;

            strErrorMsg += Environment.NewLine;
            strErrorMsg += Environment.NewLine;

            return strErrorMsg;
        }


    }
}
