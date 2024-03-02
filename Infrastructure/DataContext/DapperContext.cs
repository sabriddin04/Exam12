namespace Infrastructure.DataContext;
using Npgsql;
public class DapperContext
{

     private readonly string connect="Host=localhost;Port=5432;Database=ExamDb;User Id=postgres;Password=sabriddin2004";

  public NpgsqlConnection connection()
  {
    return new NpgsqlConnection(connect);
  }

}
