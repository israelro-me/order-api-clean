using System.Data;
using Microsoft.Data.SqlClient;

namespace OrderApi.Infrastructure;

public class SqlConnectionFactory(IConfiguration configuration)
{
    private readonly string _connectionString = configuration.GetConnectionString("DefaultConnection")
                                                ?? throw new InvalidOperationException(
                                                    "Connection string not configured.");

    public IDbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
}