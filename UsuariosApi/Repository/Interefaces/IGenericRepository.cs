using UsuariosApi.Models;

namespace UsuariosApi.Repository.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    List<T> Get(parameters [] params);
    Task<T> FindByIdAsync(int id, T entity);
    Task<T> FindByIdAsync(string id, T entity);
    Task<IEnumerable<T>> FindAllAsync(T entity);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task SaveChangesAsync();
}