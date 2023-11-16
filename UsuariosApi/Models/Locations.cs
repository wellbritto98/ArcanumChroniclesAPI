using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

[Table("locations")]
public class Location
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    [ForeignKey("Polo")]
    public int PoloId { get; set; }
    public virtual Polo Polo { get; set; }

    [Required]
    public int Quality { get; set; } = 0;

    [Required]
    public LocationType TypeId { get; set; } // Agora usando o enum

    [ForeignKey("Company")]
    public int? CompanyId { get; set; } // Nullable para permitir que não haja uma empresa associada
    public virtual Company Company { get; set; } // Supondo que você tenha uma classe Company

    [Column(TypeName = "bigint")]
    public long Money { get; set; } = 0;
}
