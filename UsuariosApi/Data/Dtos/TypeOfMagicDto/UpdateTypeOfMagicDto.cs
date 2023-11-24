using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Dtos.TypeOfMagicDto;

public class UpdateTypeOfMagicDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
}