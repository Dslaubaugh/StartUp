using System.Data.Common;
using Npgsql;
using StartUp.Web.models;

namespace StartUp.Web.database;

public interface IDBConnectionFactory
{
    DbConnection GetDbConnection();
    string GetConnectionString();
}

public class DBConnectionFactory: IDBConnectionFactory
{
    private readonly string _connectionString;

    public DBConnectionFactory(AppSettings appSettings)
    {
        var connectionBuilder = new NpgsqlConnectionStringBuilder()
        {
            Username = appSettings.StartUpDBConnection.UserName,
            Password = appSettings.StartUpDBConnection.Password,
            Database = appSettings.StartUpDBConnection.Name,
            Host = appSettings.StartUpDBConnection.Hostname,
        };

        _connectionString = connectionBuilder.ConnectionString;
    }

    public string GetConnectionString()
    {
        return _connectionString;
    }

    public DbConnection GetDbConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}