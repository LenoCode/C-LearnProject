using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SqlTransfDataAccess.Models.ClientDatabaseModels;


[Table("client_database")]
public class Database
{
    [Column("DbId")]
    public int Id { get; set; }
    
    [MaxLength(150)]
    public string? Name { get; set; }

    public List<Configuration> DbConfigurations { get; set; }


}