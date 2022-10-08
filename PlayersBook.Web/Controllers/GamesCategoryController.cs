using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayersBook.Application.Interfaces;

namespace PlayersBook.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesCategoryController : ControllerBase
    {
        private readonly ILogger<GamesCategoryController> logger;
        private readonly IGamesCategoryService gamesCategoryService;

        public GamesCategoryController(ILogger<GamesCategoryController> logger, IGamesCategoryService gamesCategoryService)
        {
            this.logger = logger;
            this.gamesCategoryService = gamesCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTopGamesCategory()
        {
            return Ok(await gamesCategoryService.GetTopGamesCategoryTwitchAsync()); 
        }
    }
}
