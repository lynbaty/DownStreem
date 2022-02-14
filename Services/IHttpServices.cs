
namespace downstreem.Services
{
    public interface IHttpServices<T>
    {
        Task<List<T>> GetAll(string url);
        Task<T> GetbyId(int id, string url);
    }
}