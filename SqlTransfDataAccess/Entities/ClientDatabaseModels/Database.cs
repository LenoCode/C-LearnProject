using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SqlTransfDataAccess.Models.ClientDatabaseModels;


[Table("client_database")]
public class Database
{
    [Column("DbId")]
    public int Id { get; set; }
    
    [MaxLength(100)]
    public string? Name { get; set; }
    
    
}