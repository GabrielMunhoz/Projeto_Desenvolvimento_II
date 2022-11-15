using Microsoft.AspNetCore.Http;

namespace PlayersBook.Application.Interfaces
{
    public interface IFileService
    {
        Task<string> SaveFilesAsync(IFormFile file, string playerId);
    }
}
