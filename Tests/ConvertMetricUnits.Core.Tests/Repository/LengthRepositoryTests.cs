using ConvertMetricUnits.Core.Repository.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Moq;
using ConvertMetricUnits.Core.Repository;

namespace ConvertMetricUnits.Core.Tests.Repository
{
    [TestClass]
    public class LengthRepositoryTests
    {
        private LengthRepository lengthRepoMock;
        private IConfiguration configuration;
        private IDistributedCache cache;

        [TestInitialize]
        public void SetUp()
        {
            lengthRepoMock = new LengthRepository(configuration,cache);
        }

        [TestMethod]
        public void GetLengthFormula_GivenToAndFromValue_ReturnsTheRightFormula()
        {
            
        }
    }
}

    
    

 
