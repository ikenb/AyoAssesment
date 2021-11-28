using AutoMapper;
using ConvertMetricUnits.API.Controllers;
using ConvertMetricUnits.Core.Repository.Interfaces;
using ConvertMetricUnits.Data.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ConvertMetricUnits.API.Tests.Controllers
{
    [TestClass]
    public class UsersControllerTests
    {
        private Mock<IUserRepository> mockUserRepository;
        private UsersController controller;
        private  IMapper mockMapper;
        private UserDto userDto;


        [TestInitialize]
        public void SetUp()
        {
            mockUserRepository = new Mock<IUserRepository>();
     
            controller = new UsersController(mockUserRepository.Object, mockMapper);

            userDto = new UserDto()
            {
                Username = ""
            };

        }

        [TestMethod]
        public void Authenticate_WhenUserIsNull_ReturnBadRequest()
        {
            var actionResult = controller.Authenticate(null);

            Assert.IsInstanceOfType(actionResult,typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void Authenticate_WhenUserIsNotNull_ReturnOk ()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void Register_WhenUserNameIsNull_ReturnBadRequest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void Register_WhenUserNameIsNotUnique_ReturnBadRequest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void Register_WhenUserIsNotNull_ReturnOk()
        {
            Assert.Inconclusive();
        }
    }
}
