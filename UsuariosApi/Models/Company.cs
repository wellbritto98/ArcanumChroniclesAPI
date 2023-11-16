using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("companies")]
public class Company
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

    public CompanyType Type { get; set; }

    [Column(TypeName = "bigint")]
    public long Money { get; set; } = 0;

    public virtual ICollection<Location> Locations { get; set; }

    public virtual ICollection<CompanyShareholder> CompanyShareholders { get; set; }
}
