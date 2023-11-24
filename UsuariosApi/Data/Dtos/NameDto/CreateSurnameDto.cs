using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Dtos.CharacterDto;

public class CreateSurnameDto
{
    [Required]
    public string SurnameChar { get; set; }
}