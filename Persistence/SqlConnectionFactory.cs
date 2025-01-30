using Application.Abstraction;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Persistence;
public class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("localdb")
            ?? throw new ApplicationException("Connection string is missing");
    }

    public SqlConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
}