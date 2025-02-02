using Microsoft.Data.SqlClient;

namespace Domain.Abstraction;
public interface ISqlConnectionFactory
{
    SqlConnection CreateConnection();
}