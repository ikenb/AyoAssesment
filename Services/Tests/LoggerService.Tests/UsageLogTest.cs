using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService.Tests
{
    [TestClass]
    public class UsageLogTest
    {
        FakeLogDetail? fakeLogDetail;
        FakeLogDetail? fakeLogDetailNoName;

        [TestInitialize]
        public void SetUp()
        {
            fakeLogDetail = new FakeLogDetail()
            {
                UserName = "Tshepiso"
            };

            fakeLogDetailNoName = new FakeLogDetail()
            {
                UserName = ""
            };
        }
        [TestMethod]
        public void WriteLogs_WhenCalledWithUserName_ShouldSetErrorProperty()
        {
            var logger = new UsageLog();

            logger.WriteLogs(fakeLogDetail);

            Assert.AreEqual("Tshepiso", logger.LoggedInUser);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WriteLogs_WhenCalledWithoutUserName_ShouldSetErrorProperty()
        {
            var logger = new UsageLog();

            logger.WriteLogs(fakeLogDetailNoName);

           
        }
    }
}

