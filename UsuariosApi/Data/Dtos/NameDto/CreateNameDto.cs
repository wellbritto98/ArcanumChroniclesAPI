using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Dtos.CharacterDto;

public class CreateNameDto
{
    [Required]
    public string NameChar { get; set; }
    [Required]
    public string Gender { get; set; }
}