using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("WayOfMagicAbilities")]
public class WayOfMagicAbility
{

    [Key, Column(Order = 0)]
    [ForeignKey("WayOfMagic")]
    public int WayOfMagicId { get; set; }
    public virtual WayOfMagic WayOfMagic { get; set; }

    [Key, Column(Order = 1)]
    [ForeignKey("Ability")]
    public int AbilityId { get; set; }
    public virtual Ability Ability { get; set; }

    public bool IsGeneric { get; set; } = false;
}
