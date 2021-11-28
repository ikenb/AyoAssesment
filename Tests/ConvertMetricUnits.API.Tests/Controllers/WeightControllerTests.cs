using ConvertMetricUnits.API.Controllers;
using ConvertMetricUnits.Core.Repository.Interfaces;
using ConvertMetricUnits.Data.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ConvertMetricUnits.API.Tests.Controllers
{
    [TestClass]
    public class WeightControllerTests
    {
        private Mock<IWeightRepository> mockWeightRepository;
        private WeightController controller;
        private WeightDto weightDtoZeroAmount;
        private WeightDto weightDtoValidAmount;

        [TestInitialize]
        public void SetUp()
        {
            mockWeightRepository = new Mock<IWeightRepository>();
            controller = new WeightController(mockWeightRepository.Object);

            weightDtoValidAmount = new WeightDto()
            {
                From = "M",
                To = "K",
                Amount = 2
            };

            weightDtoZeroAmount = new WeightDto()
            {
                From = "M",
                To = "K",
                Amount = 0
            };
        }

        [TestMethod]
        public void GetLength_WhenAmountValueIsZero_ReturnNotFound()
        {
            var actionResult = controller.GetWeight(weightDtoZeroAmount);


            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetLength_WhenAmountValueIsNotZero_ReturnOk()
        {

            var actionResult = controller.GetWeight(weightDtoValidAmount);

            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
        }
    }
}

