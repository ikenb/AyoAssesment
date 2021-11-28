using LoggerService.Enums;
using LoggerService.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serilog;

namespace LoggerService.Tests.Factory
{
    [TestClass]
    public class ConfigFactoryTests
    {
        [DataTestMethod]
        [DataRow(LogType.Usage)]
        [DataRow(LogType.Error)]
        public void GetLogType_WhenPassedValidLogType_ReturnsLoggerConfiguration(LogType logType)
        {
            var result = ConfigFactory.GetLogType(logType);

            Assert.IsNotNull(result);
        }

    }
}
