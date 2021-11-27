using Jace;

namespace ConvertMetricUnits.Core.Helpers
{
    public class MetricConverter
    {
        public static double ComputeMetric(string fromValueVariable, int toValueAmount, string formula)
        {
            try
            {
                var variables = new Dictionary<string, double>();
                variables.Add(fromValueVariable, toValueAmount);

                var engine = new CalculationEngine();

                return engine.Calculate(formula, variables);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
           

        }
    }
}
