using GestionRecetas.Domain.Entities;

namespace GestionRecetas.Application.Contratos
{
    public interface IRepositorioGenerico<T> where T : Receta
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
