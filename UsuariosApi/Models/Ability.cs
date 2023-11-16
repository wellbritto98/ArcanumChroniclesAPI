using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("Abilities")]
public class Ability
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    [Required]
    [StringLength(1000)] 
    public string Description { get; set; }

    public float Progress { get; set; } = 0;

    public virtual ICollection<WayOfMagicAbility> WayOfMagicAbilities { get; set; }
}
