using System.ComponentModel.DataAnnotations.Schema;

[Table("WayOfMagicSpells")]
public class WayOfMagicSpell
{
    [ForeignKey("WayOfMagic")]
    public int WayOfMagicId { get; set; }
    public virtual WayOfMagic WayOfMagic { get; set; }

    [ForeignKey("Spell")]
    public int SpellId { get; set; }
    public virtual Spell Spell { get; set; }

    public bool IsGeneric { get; set; } = false;
}
