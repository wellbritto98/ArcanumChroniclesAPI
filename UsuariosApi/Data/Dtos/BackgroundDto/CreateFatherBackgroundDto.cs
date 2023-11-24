using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Dtos.BackgroundDto;

public class CreateFatherBackgroundDto
{   
    [Required]
    public string Description { get; set; }
}