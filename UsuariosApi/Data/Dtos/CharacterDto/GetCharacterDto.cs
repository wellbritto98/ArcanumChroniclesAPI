using System;
using System.ComponentModel.DataAnnotations;
using UsuariosApi.Enums;

public class GetCharacterDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Surname { get; set; }
    [Required]
    public GenderEnum Gender { get; set; }
    [Required]
    public string CharacterAvatarUrl { get; set; }
    [Required]
    public int Age { get; set; }
    [Required]
    public int Health { get; set; }
    [Required]
    public int Energy { get; set; }
    [Required]
    public int Thinkings { get; set; }
    [Required]
    public int CurrentLocationId { get; set; }
    [Required]
    public string CurrentLocationName { get; set; }
    
    public string CurrentLocationPoloName { get; set; }
    [Required]
    public int WayOfMagicId { get; set; }
    public string WayOfMagicName { get; set; }
}
