namespace App.Database
{
    using System.Data;
    using System.Data.SqlClient;

    public class SQLDbProvider
    {
        public IDbConnection GetConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }

        public IDbCommand GetCommand(string command)
        {
            return new SqlCommand(command);
        }

        public IDbCommand GetCommand(string command, IDbConnection connection)
        {
            return new SqlCommand(command, (SqlConnection)connection);
        }

        public IDbDataParameter GetParameter(string parameterName, DbType parameterType)
        {
            return new SqlParameter(parameterName, parameterType);
        }

        public IDbDataParameter GetParameter(string parameterName, DbType parameterType, object value)
        {
            var p = this.GetParameter(parameterName, parameterType);
            p.Value = value;
            return p;
        }
    }
}