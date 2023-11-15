using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Dtos.UsuarioDtos
{
    public class ChangeUserRoleDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
