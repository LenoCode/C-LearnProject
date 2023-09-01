using Microsoft.EntityFrameworkCore;
using SqlTransfDataAccess.Models.ClientDatabaseModels;
using Microsoft.Extensions;
using Microsoft.Extensions.Configuration;

namespace SqlTransfDataAccess.Context;

public class ClientDatabaseContext : DbContext
{
    //Dependency injection - > services injected
    private IConfiguration _configuration;
    
    /*
     * SETS
     */
    public DbSet<Database> ClientDatabases { get; set; }
    public DbSet<Configuration> DbConfiguration { get; set; }
    
    /**
     * <summary>
     *  Constructor for migrations
     * </summary>
     *
     * <remarks>
     *  It will setup configuration from SqlTransfDataAccess objects
     * </remarks>
     */
    public ClientDatabaseContext()
    {
        
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        _configuration = builder.Build();
        
        Console.WriteLine(_configuration["Test"]);
    }
    
    public ClientDatabaseContext(DbContextOptions<ClientDatabaseContext> options,IConfiguration _configuration) : base(options)
    {
        this._configuration = _configuration;
    }

    /**
     * <summary>
     *          Configuring database override.Purpose is to
     *          check if it is called from migration tool, then to use default database
     * </summary>
     */
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Console.WriteLine("Hello Dear friend");
        if (!optionsBuilder.IsConfigured)
        {
            Console.WriteLine("Not configured");
            optionsBuilder.UseNpgsql(_configuration["ConnectionStrings:default"]);
        }
    }
    
    
    
}