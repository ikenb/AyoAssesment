using LoggerService.Logger;

namespace ConvertMetricUnits.Core.Helpers
{
    public static class LogHelper
    {
        public static void LogUsage(string userId, string userName)
        {
            var usageInfo = new LogDetail()
            {     
                Timestamp = DateTime.Now,
                UserId = userId,
                UserName = userName,
                MachineName = Environment.MachineName
                       
            };

            Logger.WriteUsageLogs(usageInfo);
        }
          

        public static void LogErrors(Exception ex)
        {
            var errorInfo = new LogDetail()
            {
                Timestamp = DateTime.Now,
                Message = ex.Message,
                MachineName = Environment.MachineName

            };

            Logger.WriteErrorLogs(errorInfo);
        }


    }
}

