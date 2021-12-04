using Jace;

namespace ConvertMetricUnits.Core.Helpers
{
    public class MetricConverter
    {
        public static double ComputeMetric(string fromValueVariable, double toValueAmount, string formula)
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
                //LogHelper.LogErrors(e);
                throw new Exception(e.Message);
            }
           

        }
    }
}
