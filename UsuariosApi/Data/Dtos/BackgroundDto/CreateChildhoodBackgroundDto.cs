using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Dtos.BackgroundDto;

public class CreateChildhoodBackgroundDto
{
    [Required]
    public string Description { get; set; }
}