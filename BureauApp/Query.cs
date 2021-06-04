using System.Configuration;
using MySql.Data.MySqlClient;

namespace BureauApp
{
    public class Query
    {
        private string sql;
        public string Sql 
        { 
            get
            {
                return sql;
            }
            set
            {
                this.sql = value;
            }
        }
        private MySqlConnection conn;
        public MySqlConnection Conn 
        { 
            get
            {
                return conn;
            }
        }

        public Query()
        {
            string connectionString = ConfigurationManager.AppSettings["connectionString"];
            conn = new MySqlConnection(connectionString);
        }
    }
}
