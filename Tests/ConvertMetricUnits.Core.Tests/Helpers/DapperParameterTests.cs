using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dapper;
using ConvertMetricUnits.Core.Helpers;
using System;

namespace ConvertMetricUnits.Core.Tests.Helpers
{
   
    [TestClass]
    public class DapperParameterTests
    {
      
        [TestMethod]
        public void BuildDapperParameters_WhenCalledWithValidParameter_ReturnsDapperParameters()
        {
            var param = DapperParameter.BuildDapperParameters("name");

            Assert.IsNotNull(param);
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BuildDapperParameters_WhenCalledWithNull_ReturnsDapperParameters()
        {
            DapperParameter.BuildDapperParameters(null);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BuildDapperParameters_WhenCalledWithEmptyString_ReturnsDapperParameters()
        {
            DapperParameter.BuildDapperParameters("");

        }
    }
}
