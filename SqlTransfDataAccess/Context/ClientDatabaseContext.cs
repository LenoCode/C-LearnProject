using Microsoft.EntityFrameworkCore;
using SqlTransfDataAccess.Models.ClientDatabaseModels;

namespace SqlTransfDataAccess.Context;

public class ClientDatabaseContext : DbContext
{
    private const string CONNECTION_STRING_DEFAULT = "Server=localhost;Port=5432;Database=ClientDatabase;Uid=postgres;";

    public DbSet<Database> ClientDatabases { get; set; }
    
    
    public ClientDatabaseContext(DbContextOptions<ClientDatabaseContext> options) : base(options) 
    {
        Console.WriteLine("Hey");
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Console.WriteLine("Configuring");
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(CONNECTION_STRING_DEFAULT);
        }
    }
    
    
    
}