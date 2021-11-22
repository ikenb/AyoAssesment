﻿using ConvertMetricUnits.Core.Helpers;
using ConvertMetricUnits.Core.Repository.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ConvertMetricUnits.Core.Repository
{
    public class LengthRepository : ILengthRepository
    {
        private readonly IDbConnection _db;

        public LengthRepository(IConfiguration configuration)
        {
            _db =  new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public double ConvertLength(string from, string to, int amount)
        {
            var converstionName = string.Concat(from, " to ", to);
            var parameter = DapperParameter.BuildDapperParameters(converstionName);
            
            var result = _db.Query<string>("Getformula",parameter, commandType: CommandType.StoredProcedure).ToList().FirstOrDefault() ;
            
            return MetricConverter.ComputeMetric(from, amount, result);
          
        }

      
    }
}
