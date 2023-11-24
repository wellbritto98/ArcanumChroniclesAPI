using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Dtos.UsuarioDtos;

public class CreateUsuarioDto
{

    [Required]
    public string Email { get; set; }
    [Required]
    public DateTime DataNascimento { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Senha { get; set; }
    [Required]
    [Compare("Senha")]
    [DataType(DataType.Password)]
    public string ConfirmacaoSenha { get; set; }
    
    [Required]
    public bool AceitaTermos { get; set; }

}
