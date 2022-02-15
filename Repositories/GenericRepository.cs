using downstreem.Data;
using downstreem.Models;
using downstreem.Specifications;
using Microsoft.EntityFrameworkCore;

namespace downstreem.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDataContext _context;

        public GenericRepository(ApplicationDataContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetbyId(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(t => t.Id == id);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task<List<T>> GetAllwithSpec(IBaseSpecification<T> spec)
        {
            return await AddSpec(spec).ToListAsync();
        }

        public IQueryable<T> AddSpec(IBaseSpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec); 
        }
    }
}
