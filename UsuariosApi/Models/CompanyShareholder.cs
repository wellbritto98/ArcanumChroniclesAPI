using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("company_shareholders")]
public class CompanyShareholder
{
    [Key, Column(Order = 0)]
    [ForeignKey("Character")]
    [DatabaseGenerated(DatabaseGeneratedOption.None)] 
    public int CharacterId { get; set; }

    [Key, Column(Order = 1)]
    [ForeignKey("Company")]
    [DatabaseGenerated(DatabaseGeneratedOption.None)] 
    public int CompanyId { get; set; }

    public virtual Character Character { get; set; }
    public virtual Company Company { get; set; }

    [Required]
    public int Shares { get; set; }

    
    public bool IsPresident { get; set; }
}
