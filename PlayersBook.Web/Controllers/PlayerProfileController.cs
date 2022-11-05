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
        private readonly ILogger<PlayerProfileController> logger;

        public PlayerProfileController(IPlayerProfileService playerProfileService, ILogger<PlayerProfileController> logger)
        {
            this.playerProfileService = playerProfileService;
            this.logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            logger.LogInformation($"Method: {nameof(GetAllAsync)} -- Controller: {nameof(PlayerProfileController)}");

            return Ok(await playerProfileService.GetallAsync()); 
        }
    }
}
