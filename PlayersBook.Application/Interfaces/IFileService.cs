using Microsoft.AspNetCore.Http;

namespace PlayersBook.Application.Interfaces
{
    public interface IFileService
    {
        Task<bool> SaveFilesAsync(IFormFile file, string playerId);
    }
}
