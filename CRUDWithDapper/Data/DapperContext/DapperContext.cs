using Microsoft.Data.SqlClient;
using System.Data;

namespace CRUDWithDapper.Data.DapperContext
{
    public class DapperContext : IDapperContext
    {
        private readonly IConfiguration _config;
        private readonly string _connString;

        public DapperContext(IConfiguration config)
        {
            _config = config;
            _connString = _config.GetConnectionString("DapperConnectionString");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connString);


    }
}
