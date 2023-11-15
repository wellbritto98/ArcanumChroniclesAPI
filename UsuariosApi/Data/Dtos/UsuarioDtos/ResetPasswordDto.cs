using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Dtos.UsuarioDtos
{
    public class ResetPasswordDto
    {
        [Required]
        public string Token { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [Required]
        [Compare("Senha")]
        [DataType(DataType.Password)]
        public string ConfirmacaoSenha { get; set; }
    }
}
