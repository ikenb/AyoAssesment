using LoggerService.Enums;
using Serilog;

namespace LoggerService.Factory
{
    public static class ConfigFactory
    {
        public static Serilog.Core.Logger GetLogType(LogType logType)
        {
            switch (logType)
            {
                case LogType.Error:
                    return new LoggerConfiguration()
                  .WriteTo.Elasticsearch("http://localhost:9200",
                              indexFormat: "error-{0:yyyy.MM.dd}",
                              inlineFields: true)
                  .CreateLogger();

                case LogType.Usage:
                    return new LoggerConfiguration()
              .WriteTo.Elasticsearch("http://localhost:9200",
                          indexFormat: "usage-{0:yyyy.MM.dd}",
                          inlineFields: true)
              .CreateLogger();

                default:
                    throw new ArgumentException("No Sinks Available");

            }
        }
    }
}

