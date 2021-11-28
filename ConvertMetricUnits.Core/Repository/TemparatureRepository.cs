﻿using ConvertMetricUnits.Core.Helpers;
using ConvertMetricUnits.Core.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Data.SqlClient;
using Dapper;


using System.Data;

namespace ConvertMetricUnits.Core.Repository
{
    public class TemparatureRepository : ITemparatureRepository
    {
        private readonly IDbConnection _db;
        private readonly IDistributedCache _cache;

        public TemparatureRepository(IConfiguration configuration, IDistributedCache cache)
        {
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            _cache = cache;
        }
        public double ConvertTemparature(string from , string to, double amount)
        {
            var converstionName = string.Concat(from, " to ", to);
            var parameter = DapperParameter.BuildDapperParameters(converstionName);

            var recordKey = converstionName;
            string formula;

            if (string.IsNullOrEmpty(_cache.GetString(recordKey)))
            {
                formula = GetTemparatureFormula(parameter);

                _cache.SetString(recordKey, formula);
            }
            else
            {
                formula = _cache.GetString(recordKey);
            }

            return MetricConverter.ComputeMetric(from, amount, formula);
        }

        public string GetTemparatureFormula(DynamicParameters parameter)
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
