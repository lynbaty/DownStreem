namespace downstreem.Services
{
    public class ImageUpload : IImageUpload
    {
        private readonly IWebHostEnvironment _env;

        public ImageUpload(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> UpImageAsync(IFormFile file)
        {
            string wwwRootPath = _env.WebRootPath;
            string extension = Path.GetExtension(file.FileName);
            var name = Guid.NewGuid() + extension;
            string path = Path.Combine(wwwRootPath, "images/entities", name);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return "images/entities/" + name;
        }

        public void Delete(string filename)
        {
            string wwwRootPath = _env.WebRootPath;
            string path = Path.Combine(wwwRootPath, filename);
            if (File.Exists(path)) File.Delete(path);
        }
    }
}
