using LoggerService;
using LoggerService.Interfaces;

namespace ConvertMetricUnits.Core.Helpers
{
    public static class LogHelper
    {
        private static readonly ILogger errorLog;
        private static readonly ILogger usageLog;

        static LogHelper()
        {
             errorLog = new ErrorLog();
             usageLog= new UsageLog();
        }
        public static void LogUsage(string userName)
        {
            var usageInfo = new LogDetail()
            {     
                Timestamp = DateTime.Now,
                UserName = userName,
                MachineName = Environment.MachineName
                       
            };

            usageLog.WriteLogs(usageInfo);
        }
          

        public static void LogErrors(Exception ex)
        {
            var errorInfo = new LogDetail()
            {
                Timestamp = DateTime.Now,
                Message = ex.Message,
                MachineName = Environment.MachineName

            };

            errorLog.WriteLogs(errorInfo);
        }


    }
}

