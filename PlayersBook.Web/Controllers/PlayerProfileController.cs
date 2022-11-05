using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayersBook.Application.Interfaces;

namespace PlayersBook.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class PlayerProfileController : ControllerBase
    {
        private readonly IPlayerProfileService playerProfileService;
        private readonly IFileService fileService;
        private readonly ILogger<PlayerProfileController> logger;

        public PlayerProfileController(IPlayerProfileService playerProfileService, IFileService fileService, ILogger<PlayerProfileController> logger)
        {
            this.playerProfileService = playerProfileService;
            this.fileService = fileService;
            this.logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            logger.LogInformation($"Method: {nameof(GetAllAsync)} -- Controller: {nameof(PlayerProfileController)}");

            return Ok(await playerProfileService.GetallAsync()); 
        }

        [HttpPost("uploadprofilepicture")]
        public async Task<IActionResult> PostImagePlayerProfile(List<IFormFile> files)
        {
            try
            {
                if (files.Count > 0)
                {
                    
                    return Ok(await fileService.SaveFilesAsync(files.FirstOrDefault(), ""));
                }
                else
                {
                    return StatusCode(204, "Any file were sent!");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }
        
    }
}
