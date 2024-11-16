namespace Pizzeria.Backend.Helpers
{
    public interface IFileStorage
    {
        Task<string> SaveFileAsync(byte[] content, string extention);

        Task RemoveFileAsync(string path);

    }

}
