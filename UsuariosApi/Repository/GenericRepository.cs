using UsuariosApi.Models;

namespace UsuariosApi.Repository.Interfaces;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    
}