using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace AdventureWorks.WebApi
{
    public class SerilogExceptionLogger : ExceptionLogger
    {
        private static readonly ILogger Logger;

        static SerilogExceptionLogger()
        {
            var logFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs\\log.txt");
            Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(logFileName, rollingInterval: RollingInterval.Day
                    , outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();
        }

        public override void Log(ExceptionLoggerContext context)
        {
            Logger.Error(context.Exception, RequestToString(context.Request));
        }

        private static string RequestToString(HttpRequestMessage request)
        {
            var message = new StringBuilder();

            if (request.Method != null)
            {
                message.Append(request.Method);
            }

            if (request.RequestUri != null)
            {
                message.Append(" ").Append(request.RequestUri);
            }

            return message.ToString();
        }
    }
}