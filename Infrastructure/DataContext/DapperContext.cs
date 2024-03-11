using Npgsql;

namespace Infrastructure.DapperContext;

public class DapperContext
{
    private readonly string _connection = "Host=localhost;Port=5432;Database=RestorantDb;User ID=postgres;Password=sabriddin2004";

    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(_connection);
    }
  


}
