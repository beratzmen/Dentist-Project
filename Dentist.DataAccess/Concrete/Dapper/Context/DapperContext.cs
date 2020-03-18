using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.DataAccess.Concrete.Dapper.Context
{
    public class DapperContext
    {
        public IEnumerable<T> Query<T>(string query)
        {
            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DentistContext"].ToString()))
            {
                return sqlConnection.Query<T>(query);
            }
        }
        public T QuerySingle<T>(string query)
        {
            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DentistContext"].ToString()))
            {
                return sqlConnection.QuerySingle<T>(query);
            }
        }
    }
}
