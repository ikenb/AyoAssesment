using ConvertMetricUnits.Core.Helpers;
using ConvertMetricUnits.Core.Repository.Interfaces;
using ConvertMetricUnits.Data.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ConvertMetricUnits.Core.Repository
{
    public class LengthRepository : ILengthRepository
    {
        private readonly IDbConnection _db;
        private readonly IDistributedCache _cache;

        public string Formula { get; set; }

        public LengthRepository(IConfiguration configuration, IDistributedCache cache)
        {
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            _cache = cache;
        }

        public double ConvertLength(string from, string to, double amount)
        {
            var converstionName = string.Concat(from, " to ", to);
            var parameter = DapperParameter.BuildDapperParameters(converstionName);

            var recordKey = converstionName;
         

            if (string.IsNullOrEmpty(_cache.GetString(recordKey)))
            {
                Formula = GetLengthFormula(parameter);

                _cache.SetString(recordKey, Formula);
            }
            else
            {
                Formula = _cache.GetString(recordKey);
            }

            return MetricConverter.ComputeMetric(from, amount, Formula);  
          
        } 

        public string GetLengthFormula(DynamicParameters parameter)
        {
            try
            {
                return _db.Query<string>("Getformula", parameter, commandType: CommandType.StoredProcedure).ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                //TODO:Log Error
                throw new ExecutionEngineException("Execution failed " + e.Message);
            }
           
        }
    }
}
