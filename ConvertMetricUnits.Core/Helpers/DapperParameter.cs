using Dapper;

namespace ConvertMetricUnits.Core.Helpers
{
    public static class DapperParameter
    {
        public static DynamicParameters BuildDapperParameters(string convertionName)
        {
            if (string.IsNullOrEmpty(convertionName))
            {
                throw new ArgumentNullException("Parameter for convertionName is Null or Empty");
            }
            var parameters = new DynamicParameters();
            parameters.Add("@converstionName", convertionName);

            return parameters;
        }
    }
}
