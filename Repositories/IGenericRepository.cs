using downstreem.Models;

namespace downstreem.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        void Delete(T entity);
        Task<List<T>> GetAll();
        Task<T> GetbyId(int id);
        void Update(T entity);
    }
}