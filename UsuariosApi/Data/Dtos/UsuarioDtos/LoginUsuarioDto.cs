﻿using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Dtos.UsuarioDtos
{
    public class LoginUsuarioDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }

    }
}
