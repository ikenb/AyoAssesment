using LoggerService.Enums;
using LoggerService.Factory;
using LoggerService.Interfaces;
using Serilog.Events;


namespace LoggerService
{
    public class UsageLog:Logger
    {
        public string? LoggedInUser { get; set; }
        public override void WriteLogs(ILogDetail infoToLog)
        {
            var _usageLogger = ConfigFactory.GetLogType(LogType.Usage);

            if (!string.IsNullOrEmpty(infoToLog.UserName))
            {
                _usageLogger.Write(LogEventLevel.Information, infoToLog.UserId, infoToLog.UserName);
                LoggedInUser = infoToLog.UserName;
            }
            else
                throw new ArgumentNullException("The value of username is null or empty");
           
        }
    }
}
