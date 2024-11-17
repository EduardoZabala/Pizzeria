using Microsoft.EntityFrameworkCore;
using Pizzeria.Backend.Data;
using Pizzeria.Shared.Entities;


namespace Pizzeria.Backend.Helpers
{
    public class FileStorage : IFileStorage
    {
        private readonly DataContext _dbContext;
        private readonly string _basePath;

        public FileStorage(DataContext dbContext)
        {
            _dbContext = dbContext;
            var projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.FullName;
            if (projectDirectory == null)
            {
                throw new InvalidOperationException("No se pudo determinar el directorio del proyecto.");
            }
            _basePath = Path.Combine(projectDirectory, "Data");
        }

        public async Task<byte[]> ProccessFile(string relativaRuta)
        {
            try
            {
                string rutaArchivo = Path.Combine(_basePath, relativaRuta);
                if (string.IsNullOrEmpty(rutaArchivo) || !File.Exists(rutaArchivo))
                {
                    throw new FileNotFoundException("El archivo no existe o la ruta es inválida.");
                }

                byte[] arrBytes;

                using (var stream = new FileStream(rutaArchivo, FileMode.Open, FileAccess.Read))
                {
                    arrBytes = new byte[stream.Length];
                    await stream.ReadAsync(arrBytes, 0, arrBytes.Length);
                }
                return arrBytes;
            }catch(Exception ex)
            {
                return [];
            }
            
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
