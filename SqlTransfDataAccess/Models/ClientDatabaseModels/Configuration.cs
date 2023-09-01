using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SqlTransfDataAccess.Models.ClientDatabaseModels;

[Table("db_configuration")]
public class Configuration
{
    public long Id { get; set; }
    
    [MaxLength(50)]
    public string Host { get; set; }

    public int Port { get; set; }
    
    [Column("database")]
    public Database DbInfo { get; set; }
    
    [Column("username")]
    [MaxLength(100)]
    public string User { get; set; }
    
    [Column("password")]
    [MaxLength(100)]
    public string Pass { get; set; }
    
    
    [NotMapped]
    public string StoringPass
    {
        get
        {
            return Pass;
        }
        
        set
        {
            Pass = "Kingkong" + value;
        } 
    }
}