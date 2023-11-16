using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Spells")]
public class Spell
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    [Required]
    [StringLength(1000)] // Ajuste o tamanho conforme necessário
    public string Description { get; set; }
    public virtual ICollection<WayOfMagicSpell> WayOfMagicSpells { get; set; }
}
