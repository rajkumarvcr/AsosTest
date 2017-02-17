namespace App.Database
{
    using System.Data;

    public interface IDatabaseProvider
    {
        IDbConnection GetConnection(string connectionString);

        IDbCommand GetCommand(string command);

        IDbCommand GetCommand(string command, IDbConnection connection);

        IDbDataParameter GetParameter(string parameterName, DbType parameterType);

        IDbDataParameter GetParameter(string parameterName, DbType parameterType, object value);
    }
}