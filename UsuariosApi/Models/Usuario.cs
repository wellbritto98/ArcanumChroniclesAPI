﻿using Microsoft.AspNetCore.Identity;

namespace UsuariosApi.Models
{
    public class Usuario : IdentityUser
    {
        public DateTime DataNascimento { get; }
        public Usuario() :base() { }
    }
}