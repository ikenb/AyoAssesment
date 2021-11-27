using Serilog;
using Serilog.Events;
using System.Diagnostics;

namespace LoggerService.Logger
{
    public static class Logger
    {
        private static readonly ILogger _usageLogger;
        private static readonly ILogger _errorLogger;

        static Logger()
        {

            _usageLogger = new LoggerConfiguration()
                .WriteTo.Elasticsearch("http://localhost:9200",
                            indexFormat: "usage-{0:yyyy.MM.dd}",
                            inlineFields: true)
                .CreateLogger();

            _errorLogger = new LoggerConfiguration()
                .WriteTo.Elasticsearch("http://localhost:9200",
                            indexFormat: "error-{0:yyyy.MM.dd}",
                            inlineFields: true)
                .CreateLogger();      

            Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));
        }

        public static void WriteUsageLogs(LogDetail infoToLog)
        {
         
            _usageLogger.Write(LogEventLevel.Information, infoToLog.UserId, infoToLog.UserName);
        }
        public static void WriteErrorLogs(LogDetail infoToLog)
        {
            if (infoToLog.Exception != null)
            {  
                infoToLog.Message = GetMessageFromException(infoToLog.Exception);
            }

            _errorLogger.Write(LogEventLevel.Error, infoToLog.Timestamp.ToString(), infoToLog.Message, infoToLog.Exception);
        }

        private static string GetMessageFromException(Exception ex)
        {
            if (ex.InnerException != null)
                return GetMessageFromException(ex.InnerException);

            return ex.Message;
        }
    }
}