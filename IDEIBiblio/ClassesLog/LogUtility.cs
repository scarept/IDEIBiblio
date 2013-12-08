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

            string strErrorMsg = Environment.NewLine + "Erro na URL:\t" + System.Web.HttpContext.Current.Request.Path;

            // Obtém a URL do erro
            strErrorMsg += Environment.NewLine + "URL Completa:\t" + System.Web.HttpContext.Current.Request.RawUrl;

            // Obtém a mensagem do erro
            strErrorMsg += Environment.NewLine + "Mensagem:\t" + logException.Message;

            // Obtém a origem do erro
            strErrorMsg += Environment.NewLine + "Origem:\t" + logException.Source;

            // Obtém a Stack Trace do erro
            strErrorMsg += Environment.NewLine + "Stack Trace:\t" + logException.StackTrace;

            // Obtém o método que ocorreu o erro
            strErrorMsg += Environment.NewLine + "URL destino:\t" + logException.TargetSite;

            strErrorMsg += Environment.NewLine;
            strErrorMsg += Environment.NewLine;
            return strErrorMsg;
        }

    }
}
