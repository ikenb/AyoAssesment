using ConvertMetricUnits.API.Controllers;
using ConvertMetricUnits.Core.Repository.Interfaces;
using ConvertMetricUnits.Data.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace ConvertMetricUnits.API.Tests.Controllers
{
    [TestClass]
    public class TemparateureControllerTests
    {
        private Mock<ITemparatureRepository> mockTemparatureRepository;
        private TemparatureController controller;
        private TemparatureDto temparatureDtoZeroAmount;
        private TemparatureDto temparatureDtoValidAmount;

        [TestInitialize]
        public void SetUp()
        {
            mockTemparatureRepository = new Mock<ITemparatureRepository>();
            controller = new TemparatureController(mockTemparatureRepository.Object);

            temparatureDtoValidAmount = new TemparatureDto()
            {
                From = "M",
                To = "K",
                Amount = 2
            };

            temparatureDtoZeroAmount = new TemparatureDto()
            {
                From = "M",
                To = "K",
                Amount = 0
            };

        }

        [TestMethod]
        public void GetTemparature_WhenAmountValueIsZero_ReturnNotFound()
        {
            var actionResult = controller.GetTemparature(temparatureDtoZeroAmount);


            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetLength_WhenAmountValueIsNotZero_ReturnOk()
        {

            var actionResult = controller.GetTemparature(temparatureDtoValidAmount);

            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
        }
    }
}
