using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Dtos.UsuarioDtos
{
    public class JwtTokenDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Id { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public bool hasCharacter { get; set; }
        [Required]
        public int MainCharacterId { get; set; }
        [Required]
        public int ActiveCharacter { get; set; }

        public JwtTokenDto()
        {
            ActiveCharacter = MainCharacterId;
        }
    }
}


 