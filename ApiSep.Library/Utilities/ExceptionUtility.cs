using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ApiSep.Library.Models.dto;

namespace ApiSep.Library.Utilities
{
    public static class ExceptionUtility
    {
        public static EmailUtility EmailUtility { get; set; } = new EmailUtility();

        public static void LogExceptionAndNotifyOps(Exception exc,  UserDto user, string requestUrl, [CallerFilePath]string source = "", [CallerMemberName]string method = "")
        {
            var body = "";
            try
            {
                //todo see if this still passes the caller file and caller member name
                body = LogException(exc, user, requestUrl);
            }
            catch (Exception ex)
            {
                //Welp
                NotifySystemOps("LogException", $@"Cannot access the log file.  Exception thrown {ex.Message}");
            }
            NotifySystemOps(method, body);
        }

        public static string LogException(Exception exc, UserDto user, string requestUrl,
            [CallerFilePath] string source = "", [CallerMemberName] string method = "")
        {
            return LogExceptionAsync(exc, user, requestUrl).Result;
        }

        // Log an Exception 
        public static async Task<string> LogExceptionAsync(Exception exc,  UserDto user, string requestUrl, [CallerFilePath]string source = "", [CallerMemberName]string method = "")
        {
            // Include enterprise logic for logging exceptions 
            // Get the absolute path to the log file 
            string logFile = "~/App_Data/ErrorLog.txt";
            logFile = HttpContext.Current.Server.MapPath(logFile);

            // Open the log file for append and write the log
            //var sw = new StreamWriter(logFile, true);
            var sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine($"********** {DateTime.Now} **********");

            sb.Append("HttpRequest.Url: ");
            sb.AppendLine(requestUrl);
            sb.Append("Logged in User name: ");
            sb.AppendLine(user?.Username);
            sb.Append("Exception Type: ");
            sb.AppendLine(exc.GetType().ToString());
            sb.AppendLine("Exception: " + exc.Message);
            sb.AppendLine("Source: " + source);
            sb.AppendLine("Method: " + method);
            sb.AppendLine("Stack Trace: ");
            if (exc.StackTrace != null)
            {
                sb.AppendLine(exc.StackTrace);
                sb.AppendLine();
            }
            if (exc.InnerException != null)
            {
                sb.Append("Inner Exception Type: ");
                sb.AppendLine(exc.InnerException.GetType().ToString());
                sb.Append("Inner Exception: ");
                sb.AppendLine(exc.InnerException.ToString());
                sb.Append("Inner Source: ");
                sb.AppendLine(exc.InnerException.Source);
                if (exc.InnerException.StackTrace != null)
                {
                    sb.AppendLine("Inner Stack Trace: ");
                    sb.AppendLine(exc.InnerException.StackTrace);
                }
            }

            await Task.FromResult(WriteTextAsync(logFile, sb.ToString())) ;

            return sb.ToString();
        }

        public static string LogExceptionFromApiAsync(Exception exc, string username, string dealerName, string requestUrl, [CallerFilePath]string source = "", [CallerMemberName]string method = "")
        {
            // Include enterprise logic for logging exceptions 
            // Get the absolute path to the log file 
            string logFile = "~/App_Data/ErrorLog.txt";
            logFile = HttpContext.Current.Server.MapPath(logFile);

            // Open the log file for append and write the log
            //var sw = new StreamWriter(logFile, true);
            var sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine($"********** {DateTime.Now} **********");

            sb.Append("HttpRequest.Url: ");
            sb.AppendLine(requestUrl);
            sb.Append("Logged in User name: ");
            sb.AppendLine(username);
            sb.Append("Dealer name: ");
            sb.AppendLine(dealerName);
            sb.Append("Exception Type: ");
            sb.AppendLine(exc.GetType().ToString());
            sb.AppendLine("Exception: " + exc.Message);
            sb.AppendLine("Source: " + source);
            sb.AppendLine("Method: " + method);
            sb.AppendLine("Stack Trace: ");
            if (exc.StackTrace != null)
            {
                sb.AppendLine(exc.StackTrace);
                sb.AppendLine();
            }
            if (exc.InnerException != null)
            {
                sb.Append("Inner Exception Type: ");
                sb.AppendLine(exc.InnerException.GetType().ToString());
                sb.Append("Inner Exception: ");
                sb.AppendLine(exc.InnerException.ToString());
                sb.Append("Inner Source: ");
                sb.AppendLine(exc.InnerException.Source);
                if (exc.InnerException.StackTrace != null)
                {
                    sb.AppendLine("Inner Stack Trace: ");
                    sb.AppendLine(exc.InnerException.StackTrace);
                }
            }

            byte[] encodedText = Encoding.UTF8.GetBytes(sb.ToString());

            using (var sourceStream = new FileStream(logFile,
                FileMode.Append, FileAccess.Write, FileShare.None,
                bufferSize: 4096, useAsync: true))
            {
                sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
            };

            return sb.ToString();
        }

        public static async void LogDataEntityException(DbEntityValidationException exc, UserDto user, string requestUrl, [CallerFilePath]string source = "", [CallerMemberName]string method = "")
        {
            /*var errorMessages = exc.EntityValidationErrors
                .SelectMany(x => x.ValidationErrors)
                .Select(x => x.ErrorMessage);
            var validationErrors = string.Join(", ", errorMessages.Select(z => z));*/
            //var validationErrors = string.Join("; " + Environment.NewLine, errorMessages);

            var errorMessages = new List<string>();
            foreach (DbEntityValidationResult validationResult in exc.EntityValidationErrors)
            {
                errorMessages.AddRange(
                    validationResult.ValidationErrors.Select(
                        error => validationResult.Entry.Entity.GetType().Name + "." + error.PropertyName + ": " + error.ErrorMessage));
            }
            var validationErrors = string.Join("; " + Environment.NewLine, errorMessages);

            // Include enterprise logic for logging exceptions 
            // Get the absolute path to the log file 
            string logFile = "~/App_Data/ErrorLog.txt";
            logFile = HttpContext.Current.Server.MapPath(logFile);

            // Open the log file for append and write the log
            //var sw = new StreamWriter(logFile, true);
            var sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine($"********** {DateTime.Now} **********");
            sb.AppendLine("Entity Validation Error Occurred");
            sb.Append("HttpRequest.Url: ");
            sb.AppendLine(requestUrl);
            sb.Append("Logged in User name: ");
            sb.AppendLine(user?.Username);
            sb.Append("Exception Type: ");
            sb.AppendLine(exc.GetType().ToString());
            sb.AppendLine("Exception: " + exc.Message);
            sb.AppendLine("Source: " + source);
            sb.AppendLine("Method: " + method);
            sb.AppendLine("Stack Trace: ");
            if (exc.StackTrace != null)
            {
                sb.AppendLine(exc.StackTrace);
                sb.AppendLine();
            }
            if (exc.InnerException != null)
            {
                sb.Append("Inner Exception Type: ");
                sb.AppendLine(exc.InnerException.GetType().ToString());
                sb.Append("Inner Exception: ");
                sb.AppendLine(exc.InnerException.ToString());
                sb.Append("Inner Source: ");
                sb.AppendLine(exc.InnerException.Source);
                if (exc.InnerException.StackTrace != null)
                {
                    sb.AppendLine("Inner Stack Trace: ");
                    sb.AppendLine(exc.InnerException.StackTrace);
                }
            }
            sb.Append("Validation Errors: ");
            if (!string.IsNullOrWhiteSpace(validationErrors))
            {
                sb.AppendLine(validationErrors);
            }

            await WriteTextAsync(logFile, sb.ToString());

            NotifySystemOps(method, sb.ToString());
        }

        static async Task WriteTextAsync(string filePath, string text)
        {
            byte[] encodedText = Encoding.UTF8.GetBytes(text);

            using (var sourceStream = new FileStream(filePath,
                FileMode.Append, FileAccess.Write, FileShare.None,
                bufferSize: 4096, useAsync: true))
            {
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
            };
        }

        

        // Notify System Operators about an exception 
        //private static void NotifySystemOps(string method, string body)
        //{
        //    var subject = method == "LogException" ? "LOGGING FAILED!" : "Exception Encountered";

        //    Task.Factory.StartNew(() =>
        //    {
        //        EmailUtility.NotifySystemOpsOfException(subject, body);
        //    });
        //}

        //Exchange way
        private static void NotifySystemOps(string method, string body)
        {
            //var request = new EmailRequest
            //{
            //    IdUser = 0,
            //    Subject = method == "LogException" ? "LOGGING FAILED!" : "Exception Encountered",
            //    Body = body,
            //    ToRecipients = new List<string> { ConfigurationManager.AppSettings["SupportEmail"] },
            //    IdDealer = 0,
            //    RequestDateTime = DateTime.Now,
            //    HasAttachment = false,
            //    ShouldSend = true
            //};

            //Task.Factory.StartNew(() =>
            //{
            //    EmailUtility.NotifySystemOpsOfException(request);
            //});
        }

        public static void MessageSystemOps(string subject, string body)
        {
            //var request = new EmailRequest
            //{
            //    IdUser = 0,
            //    Subject = subject,
            //    Body = body,
            //    ToRecipients = new List<string> { ConfigurationManager.AppSettings["SupportEmail"] },
            //    IdDealer = 0,
            //    RequestDateTime = DateTime.Now,
            //    HasAttachment = false,
            //    ShouldSend = true
            //};

            //Task.Factory.StartNew(() =>
            //{
            //    EmailUtility.NotifySystemOpsOfException(request);
            //});
        }

        /// <summary>
        /// Convert Enumerable in hierarchy format to Enumerable collection.
        /// </summary>
        /// <typeparam name="TSource">Originating source collection type.</typeparam>
        /// <param name="source">Originating source collection type.</param>
        /// <param name="nextItem">Function to retrieve next item in collection.</param>
        /// <param name="canContinue">Boolean function indicating if next item exists.</param>
        /// <returns>The collection from a hierarchical format.</returns>
        public static IEnumerable<TSource> FromHierarchy<TSource>(
            this TSource source,
            Func<TSource, TSource> nextItem,
            Func<TSource, bool> canContinue)
        {
            for (var current = source; canContinue(current); current = nextItem(current))
            {
                yield return current;
            }
        }

        /// <summary>
        /// Recursively enumerates over hierarchy to get collection.
        /// </summary>
        /// <typeparam name="TSource">Originating source collection type.</typeparam>
        /// <param name="source">Originating source collection type.</param>
        /// <param name="nextItem">Function to retrieve next item in collection.</param>
        /// <returns>Single yielded enumerable object.</returns>
        public static IEnumerable<TSource> FromHierarchy<TSource>(
            this TSource source,
            Func<TSource, TSource> nextItem)
            where TSource : class
        {
            return FromHierarchy(source, nextItem, s => s != null);
        }
    }


}

