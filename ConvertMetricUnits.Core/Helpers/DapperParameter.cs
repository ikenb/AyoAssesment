using Dapper;
using System;

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

        public static DynamicParameters BuildDapperSaveUserParameters(string username, string password, string role)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)|| string.IsNullOrEmpty(role))
            {
                throw new ArgumentNullException("One or more Parameter for user is Null or Empty");
            }
            var parameters = new DynamicParameters();
            parameters.Add("@username", username);
            parameters.Add("@password", password);
            parameters.Add("@role", role);

            return parameters;
        }

        public static DynamicParameters BuildDapperGetUserParameters(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException("One or more Parameter for user is Null or Empty");
            }
            var parameters = new DynamicParameters();
            parameters.Add("@username", username);
      
            return parameters;
        }
    }
}
