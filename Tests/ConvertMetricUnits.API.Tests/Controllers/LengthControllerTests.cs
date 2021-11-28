using ConvertMetricUnits.API.Controllers;
using ConvertMetricUnits.Core.Repository.Interfaces;
using ConvertMetricUnits.Data.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Http;

namespace ConvertMetricUnits.API.Tests.Controllers
{
    [TestClass]
    public class LengthControllerTests
    {
        private Mock<ILengthRepository> mockLengthRepository;
        private LengthController controller;
        private LengthDto lengthDtoZeroAmount;
        private LengthDto lengthDtoValidAmount;

        [TestInitialize]
        public void SetUp()
        {
        
            mockLengthRepository = new Mock<ILengthRepository>();
            controller = new LengthController(mockLengthRepository.Object);

            lengthDtoValidAmount = new LengthDto()
            {
                From = "M",
                To = "K",
                Amount = 2
            };

            lengthDtoZeroAmount = new LengthDto()
            {
                From = "M",
                To = "K",
                Amount = 0
            };

        }

        [TestMethod]
        public void GetLength_WhenAmountValueIsZero_ReturnNotFound()
        {
           var actionResult = controller.GetLength(lengthDtoZeroAmount);

   
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetLength_WhenAmountValueIsNotZero_ReturnOk()
        {
  
            var actionResult = controller.GetLength(lengthDtoValidAmount);

            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
        }
    }
}
