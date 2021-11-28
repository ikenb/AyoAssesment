using ConvertMetricUnits.API.Controllers;
using ConvertMetricUnits.Core.Repository;
using ConvertMetricUnits.Core.Repository.Interfaces;
using FluentNHibernate.Conventions.Inspections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ConvertMetricUnits.API.Tests.Controllers
{
    [TestClass]
    public class LengthControllerTests
    {
        private LengthController _lengthController;

        [TestInitialize]
        public void SetUp()
        {
            var logger = new Mock<ILogger>();
            var lenthRepositort = new Mock <ILengthRepository> ();
            
        }

        //[TestMethod]
        //public void GetLength_WhenAmountValueIsZero_ReturnNotFound()
        //{
        //    var result = _lengthController.GetLength("cm","mm",0);

        //    Assert.AreEqual(result.GetType(), typeof<NotFound>);
        //}

        //[TestMethod]
        //public void GetLength_WhenAmountValueIsNotZero_ReturnOk()
        //{
        //    var result = _lengthController.GetLength("cm", "mm", 2);

        //    Assert.IsNotNull(result);
        //}
    }
}
