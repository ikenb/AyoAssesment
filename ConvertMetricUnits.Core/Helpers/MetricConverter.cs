using Jace;

namespace ConvertMetricUnits.Core.Helpers
{
    public class MetricConverter
    {
        public static double ComputeMetric(string fromValueVariable, int fromValueAmount, string formula)
        {
            try
            {
                var variables = new Dictionary<string, double>();
                variables.Add(fromValueVariable, fromValueAmount);

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
