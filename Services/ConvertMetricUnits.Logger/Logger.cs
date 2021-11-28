using LoggerService.Interfaces;

namespace LoggerService
{
    public class Logger : ILogger
    {
        public virtual void WriteLogs(ILogDetail infoToLog)
        {
            throw new NotImplementedException();
        }
    }
}
