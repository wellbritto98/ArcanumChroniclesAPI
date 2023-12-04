using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Models
{
    public class Usuario : IdentityUser
    {
        
        public DateTime RegisteredAt { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime? LastLoginAt { get; set; }
        public string? VerificationToken { get; set; }
        public string Role { get; set; }
        public DateTime? VerificationTokenExpires { get; set; }
        public DateTime? VerifiedAt { get; set; }
        public string? PasswordResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        
        public bool hasCharacter { get; set; }

        public virtual ICollection<Character> Characters { get; set; }

        public Usuario() : base() { }
    }
}
