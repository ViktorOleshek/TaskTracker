using Microsoft.Data.SqlClient;

namespace Application.Abstraction;
public interface ISqlConnectionFactory
{
    SqlConnection CreateConnection();
}