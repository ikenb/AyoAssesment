using LoggerService;
using LoggerService.Interfaces;

namespace ConvertMetricUnits.Core.Helpers
{
    public static class LogHelper
    {
        private static readonly ILogger logger;

         static LogHelper()
        {
             logger = new Logger();
        }
        public static void LogUsage(string userId, string userName)
        {
            var usageInfo = new LogDetail()
            {     
                Timestamp = DateTime.Now,
                UserId = userId,
                UserName = userName,
                MachineName = Environment.MachineName
                       
            };

            logger.WriteLogs(usageInfo);
        }
          

        public static void LogErrors(Exception ex)
        {
            var errorInfo = new LogDetail()
            {
                Timestamp = DateTime.Now,
                Message = ex.Message,
                MachineName = Environment.MachineName

            };

            logger.WriteLogs(errorInfo);
        }


    }
}

