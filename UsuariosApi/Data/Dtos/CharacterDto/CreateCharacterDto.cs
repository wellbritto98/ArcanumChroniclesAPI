using System;
using System.ComponentModel.DataAnnotations;
using UsuariosApi.Enums;

public class CreateCharacterDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Surname { get; set; }
    [Required]
    public GenderEnum Gender { get; set; }
    public string CharacterAvatarUrl { get; set; }
    [Required]
    public int FatherBackgroundId { get; set; }
    [Required]
    public int MotherBackgroundId { get; set; }
    [Required]
    public int ChildhoodBackgroundId { get; set; }
    [Required]
    public int BirthPoloId { get; set; }
    [Required]
    public int TypeOfMagicId { get; set; }

}
