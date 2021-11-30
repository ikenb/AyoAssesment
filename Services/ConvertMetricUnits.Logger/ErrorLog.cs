using LoggerService.Enums;
using LoggerService.Factory;
using LoggerService.Interfaces;
using Serilog;
using Serilog.Events;
using System.Diagnostics;

namespace LoggerService
{
    public  class ErrorLog: Interfaces.ILogger
    {
        public string? ErrorMessage { get; set; }

        public  void WriteLogs(ILogDetail infoToLog)
        {
            var errorLogger = ConfigFactory.GetLogType(LogType.Error);

            if (infoToLog.Exception != null)
            {  
                infoToLog.Message = GetMessageFromException(infoToLog.Exception);
                ErrorMessage = infoToLog.Message;

                errorLogger.Write(LogEventLevel.Error, infoToLog.Timestamp.ToString(), ErrorMessage, infoToLog.Exception);
            }      
        }

        private string GetMessageFromException(Exception ex)
        {
            if (ex.InnerException != null)
                return GetMessageFromException(ex.InnerException);

            return ex.Message;
        }
    }
}