using LoggerService.Enums;
using LoggerService.Factory;
using LoggerService.Interfaces;
using Serilog;
using Serilog.Events;
using System.Diagnostics;

namespace LoggerService
{
    public class UsageLog: Interfaces.ILogger
    {
        public string? LoggedInUser { get; set; }
        public  void WriteLogs(ILogDetail infoToLog)
        {
             var usageLogger = ConfigFactory.GetLogType(LogType.Usage);

            if (!string.IsNullOrEmpty(infoToLog.UserName))
            {
                LoggedInUser = infoToLog.UserName;

                usageLogger.Write(LogEventLevel.Information, infoToLog.UserId, LoggedInUser);
            }
            else
                throw new ArgumentNullException("The value of username is null or empty");
           
        }
    }
}
