using ConvertMetricUnits.Core.Repository.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ConvertMetricUnits.Core.Tests.Repository
{
    [TestClass]
    public class LengthRepositoryTests
    {
        private Mock<ILengthRepository> _lengthRepoMock;

        [TestInitialize]
        public void SetUp()
        {
            _lengthRepoMock = new Mock<ILengthRepository>();
        }

        [TestMethod]
        public void ConvertLength_Given_FromVariableAndToVariable_ReturnsConvertedMetric()
        {
            
        }
    }
}

    
    

 
