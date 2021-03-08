using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace BLL.Exceptions
{
    public class LogErrors
    {
        public static void LogedError(Exception exception)
        {
            var dm = new DataManager();
            var errorMessage = "Message: " + exception.Message.Replace("'", "").Replace("\"", "") + "\nSource: " +
                               exception.Source.Replace("'", "").Replace("\"", "")
                               + "\n\n\nStackTrase: " + exception.ToString().Replace("'", "").Replace("\"", "");
            if (exception.InnerException != null)
            {
                errorMessage += "\n\n\n\n\n\n----------------------------------INNER EXCEPTION START ----------------------------------"
                                + "\n\n\nIE Message: " +
                                exception.InnerException.Message.Replace("'", "").Replace("\"", "") + "\nIE Source: " + exception.InnerException.Source.Replace("'", "").Replace("\"", "")
                                + "\n\n\nIE StackTrase: " +
                                exception.InnerException.ToString().Replace("'", "").Replace("\"", "")
                                + "\n\n\n----------------------------------INNER EXCEPTION END ----------------------------------";
            }

            dm.QueryWithoutReturnData(null, String.Format("INSERT INTO errorslog (\"Date\", \"StackTrase\", \"ErrorType\") VALUES('{0}', '{1}', '{2}')",
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), errorMessage, exception.GetType()));
        }
    }
}