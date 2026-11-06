using System.Data;
using Npgsql;

namespace Infrastructure.Data;

public class AppDbContext
{
    private string connectionString = "Host=localhost; Port=5432; Database=booknest; Username=postgres; Password=1234";
    public IDbConnection Connection()
    {
        return new NpgsqlConnection(connectionString);
    }
}