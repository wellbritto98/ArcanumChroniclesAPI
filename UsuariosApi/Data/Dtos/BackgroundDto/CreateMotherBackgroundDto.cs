using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Dtos.BackgroundDto;

public class CreateMotherBackgroundDto
{
    [Required]
    public string Description { get; set; }
}