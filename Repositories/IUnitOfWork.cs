using downstreem.Models;

namespace downstreem.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> Complete();
        void Dispose();
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
    }
}