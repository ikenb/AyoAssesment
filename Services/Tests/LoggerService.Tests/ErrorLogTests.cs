using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LoggerService.Tests
{
    
    [TestClass]
    public class ErrorLogTests
    {
        FakeLogDetail? fakeLogDetail;
        string exceptionMessage;
        [TestInitialize]
        public void SetUp()
        {
            fakeLogDetail = new FakeLogDetail()
            {
                Exception = new Exception()
            };

            exceptionMessage = "Exception of type 'System.Exception' was thrown.";
        }

        [TestMethod]
        public void WriteLogs_WhenCalled_ShouldSetErrorProperty()
        {
            var logger = new ErrorLog();

            logger.WriteLogs(fakeLogDetail);

            Assert.AreEqual(exceptionMessage, logger.ErrorMessage);
        }

    }
}