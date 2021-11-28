using LoggerService.Enums;
using LoggerService.Factory;
using LoggerService.Interfaces;
using Serilog.Events;

namespace LoggerService
{
    public  class ErrorLog:Logger
    {
        public string? ErrorMessage { get; set; }

        public override void WriteLogs(ILogDetail infoToLog)
        {
            var errorLogger = ConfigFactory.GetLogType(LogType.Error);

            if (infoToLog.Exception != null)
            {  
                infoToLog.Message = GetMessageFromException(infoToLog.Exception);
                ErrorMessage = infoToLog.Message;

                errorLogger.Write(LogEventLevel.Error, infoToLog.Timestamp.ToString(), infoToLog.Message, infoToLog.Exception);
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