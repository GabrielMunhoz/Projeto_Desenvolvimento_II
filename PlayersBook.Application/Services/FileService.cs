using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PlayersBook.Application.Interfaces;
using PlayersBook.Domain.DTOs;

namespace PlayersBook.Application.Services
{
    public class FileService: IFileService
    {
        private readonly IConfiguration configuration;
        private readonly IPlayerProfileService playerProfileService;
        private readonly ILogger<FileService> logger;

        public FileService(IConfiguration configuration, IPlayerProfileService playerProfileService, ILogger<FileService> logger)
        {
            this.configuration = configuration;
            this.playerProfileService = playerProfileService;
            this.logger = logger;
        }

        public async Task<string> SaveFilesAsync(IFormFile file, string playerId)
        {
            logger.LogInformation(String.Format(Resource.INFORMATION_LOG, nameof(SaveFilesAsync), nameof(FileService)));
            try
            {
                string fileName = GenerateNewFileName(file.FileName);
                string fileFormat = GetFileFormat(fileName);

                byte[] bytesFile = ConvertFileInByteArray(file);

                string directory = CreateFilePath(fileName);
                await System.IO.File.WriteAllBytesAsync(directory, bytesFile);

                var url = GetFileUrl(fileName);

                return url; 
            }
            catch (Exception ex)
            {
                logger.LogError(String.Format(Resource.ERROR_LOG, nameof(SaveFilesAsync), nameof(FileService), ex.Message));
                throw;
            }

        }

        #region Private Methods
        private string GetFileFormat(string fullFileName)
        {
            logger.LogInformation(String.Format(Resource.INFORMATION_LOG, nameof(GetFileFormat), nameof(FileService)));
            var format = fullFileName.Split(".").Last();
            return "." + format;
        }

        private string GenerateNewFileName(string fileName)
        {
            logger.LogInformation(String.Format(Resource.INFORMATION_LOG, nameof(GenerateNewFileName), nameof(FileService)));
            var newFileName = (Guid.NewGuid().ToString() + "_" + fileName).ToLower();
            newFileName = newFileName.Replace("-", "").Replace(" ", "");

            return newFileName;
        }

        private string CreateFilePath(string fileName)
        {
            logger.LogInformation(String.Format(Resource.INFORMATION_LOG, nameof(CreateFilePath), nameof(FileService)));
            var folder = Path.Combine(Directory.GetCurrentDirectory(), configuration["Directories:Files"]); 

            if(!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            var filePath = Path.Combine(folder, fileName);
            return filePath;
        }

        private string GetFileUrl(string fileName)
        {
            logger.LogInformation(String.Format(Resource.INFORMATION_LOG, nameof(GetFileUrl), nameof(FileService)));
            var baseUrl = configuration["Directories:BaseUrl"];

            var fileUrl = configuration["Directories:Files"]
                .Replace("wwwroot", "")
                .Replace("\\", "");

            //return (baseUrl + "/" + fileUrl + "/" + fileName);
            return (fileUrl + "/" + fileName);
        }
        private byte[] ConvertFileInByteArray(IFormFile file)
        {
            logger.LogInformation(String.Format(Resource.INFORMATION_LOG, nameof(ConvertFileInByteArray), nameof(FileService)));
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        } 
        #endregion

    }
}
