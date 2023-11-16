using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("WayOfMagic")]
public class WayOfMagic
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
    public virtual ICollection<WayOfMagicAbility> WayOfMagicAbilities { get; set; }
    public virtual ICollection<Character> Characters { get; set; }
}
