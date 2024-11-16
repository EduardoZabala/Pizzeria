using Microsoft.EntityFrameworkCore;
using Pizzeria.Backend.Data;
using Pizzeria.Shared.Entities;


namespace Pizzeria.Backend.Helpers
{
    public class FileStorage : IFileStorage
    {
        private readonly DataContext _dbContext;

        public FileStorage(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task RemoveFileAsync(string path)
        {
            var file = await _dbContext.Archivos.FirstOrDefaultAsync(f => f.FileName == path);
            if (file != null)
            {
                _dbContext.Archivos.Remove(file);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<string> SaveFileAsync(byte[] content, string extension)
        {
            var fileName = $"{Guid.NewGuid()}{extension}";

            var file = new Archivo
            {
                FileName = fileName,
                FileExtension = extension,
                Content = content,
                CreatedAt = DateTime.UtcNow
            };

            _dbContext.Archivos.Add(file);
            await _dbContext.SaveChangesAsync();
            return fileName;
        }
    }

}
