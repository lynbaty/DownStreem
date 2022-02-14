
namespace downstreem.Services
{
    public interface IImageUpload
    {
        void Delete(string filename);
        Task<string> UpImageAsync(IFormFile file);
    }
}