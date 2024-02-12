using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataContext
{
    public class DapperOrmHelper : IDapperOrmHelper
    {
        private readonly IConfiguration _configuration;
        public string ConnectionString { get; set; }
        public string ProviderName { get; }

        public DapperOrmHelper(IConfiguration configuration)
        {
            _configuration = configuration;

            ConnectionString = _configuration.GetConnectionString("DBConnection");
            ProviderName = "Npgsql";
        }

        public IDbConnection GetDapperContextHelper()
        {
            return new NpgsqlConnection(ConnectionString);
        }
    }
}
