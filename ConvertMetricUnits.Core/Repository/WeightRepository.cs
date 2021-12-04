using ConvertMetricUnits.Core.Helpers;
using ConvertMetricUnits.Core.Repository.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ConvertMetricUnits.Core.Repository
{
    public class WeightRepository : IWeightRepository
    {
        private readonly IDbConnection _db;
        private readonly IDistributedCache _cache;

        public string Formula { get; set; }
        public WeightRepository(IConfiguration configuration, IDistributedCache cache)
        {
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            _cache = cache;
        }
        public double ConvertWeight(string from, string to, double amount)
        {
            var converstionName = string.Concat(from, " to ", to);
            var parameter = DapperParameter.BuildDapperParameters(converstionName);

            //var recordKey = converstionName;
            //string formula;

            //if (string.IsNullOrEmpty(_cache.GetString(recordKey)))
            //{
                Formula = GetWeightFormula(parameter);

                //_cache.SetString(recordKey, formula);
            //}
           // else
            //{
                //Formula = _cache.GetString(recordKey);
            //}

            return MetricConverter.ComputeMetric(from, amount, Formula);

        }

        public string GetWeightFormula(DynamicParameters parameter)
        {
            try
            {
                return _db.Query<string>("Getformula", parameter, commandType: CommandType.StoredProcedure).ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                //LogHelper.LogErrors(e);
                return string.Empty;
            }

        }
    }
}
