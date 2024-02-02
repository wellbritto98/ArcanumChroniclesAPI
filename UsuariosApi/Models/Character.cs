using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UsuariosApi.Enums;
using UsuariosApi.Models;

[Table("Character")]
public class Character
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    [Required]
    [StringLength(255)]
    public string Surname { get; set; }

    [ForeignKey("Usuario")]
    public string UsuarioId { get; set; }
    public virtual Usuario Usuario { get; set; }

    [ForeignKey("FatherBackground")]
    public int FatherBackgroundId { get; set; }
    public virtual FatherBackground FatherBackground { get; set; }

    [ForeignKey("MotherBackground")]
    public int MotherBackgroundId { get; set; }
    public virtual MotherBackground MotherBackground { get; set; }

    [ForeignKey("ChildhoodBackground")]
    public int ChildhoodBackgroundId { get; set; }
    public virtual ChildhoodBackground ChildhoodBackground { get; set; }

    [Required]
    public GenderEnum Gender { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }
    
    [Required]
    [MinLength(0)]
    public int Age { get; set; }

    [ForeignKey("BirthPolo")]
    public int BirthPoloId { get; set; }
    public virtual Polo BirthPolo { get; set; }

    [ForeignKey("CurrentLocation")]
    public int CurrentLocationId { get; set; }
    public virtual Location CurrentLocation { get; set; }

    public string? CharacterAvatarUrl { get; set; }
    
    [MaxLength(255)]
    public string? Thinkings { get; set; }

    [Required]
    [MaxLength(100)]
    [MinLength(0)]
    public int Energy { get; set; } = 100;
    
    [Required]
    [MaxLength(100)]
    [MinLength(0)]
    public int Health { get; set; } = 100;
    

    [ForeignKey("WayOfMagic")]
    public int? WayOfMagicId { get; set; }
    public virtual WayOfMagic WayOfMagic { get; set; }

    [ForeignKey("TypeOfMagic")]
    public int TypeOfMagicId { get; set; }
    public virtual TypeOfMagic TypeOfMagic { get; set; }
    
    
    
    
}
