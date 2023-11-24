using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("WayOfMagicSpells")]
public class WayOfMagicSpell
{
    [Key, Column(Order = 0)]
    [ForeignKey("WayOfMagic")]
    public int WayOfMagicId { get; set; }
    public virtual WayOfMagic WayOfMagic { get; set; }

    [Key, Column(Order = 1)]
    [ForeignKey("Spell")]
    public int SpellId { get; set; }
    public virtual Spell Spell { get; set; }

    public bool IsGeneric { get; set; } = false;
}
