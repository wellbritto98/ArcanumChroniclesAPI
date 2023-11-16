using System.ComponentModel.DataAnnotations.Schema;

[Table("WayOfMagicAbilities")]
public class WayOfMagicAbility
{
    [ForeignKey("WayOfMagic")]
    public int WayOfMagicId { get; set; }
    public virtual WayOfMagic WayOfMagic { get; set; }

    [ForeignKey("Ability")]
    public int AbilityId { get; set; }
    public virtual Ability Ability { get; set; }

    public bool IsGeneric { get; set; } = false;
}
