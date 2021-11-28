using Jace;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ConvertMetricUnits.Core.Tests.Helpers
{
    [TestClass]
    public class MetricConveterTests
    {
      
        [TestMethod]
        public void ComputeMetric_GivenVariableAndValidFormula_ComputeTheResults()
        {
            var variables = new Dictionary<string, double>();
            variables.Add("var1", 2);
            variables.Add("var2", 3);

            var engine = new CalculationEngine();
            double result = engine.Calculate("var1+var2", variables);

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        [ExpectedException(typeof(Jace.ParseException))]
        public void ComputeMetric_GivenVariableAndInvalidFormula_ComputeTheResults()
        {
            var variables = new Dictionary<string, double>();
            variables.Add("var1", 2);
            variables.Add("var2", 3);

            var engine = new CalculationEngine();
            double result = engine.Calculate("var1+var2+nul...=none", variables);
            
        }
    }
}
