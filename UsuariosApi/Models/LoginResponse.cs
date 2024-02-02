namespace UsuariosApi.Models;

public class LoginResponse
{
    public string Token { get; set; }
    public string UserId { get; set; }
    public string UserEmail { get; set; }
    public bool hasCharacter { get; set; }
    
    public int MainCharacterId { get; set; }
}
