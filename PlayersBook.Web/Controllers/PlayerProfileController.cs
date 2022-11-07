using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayersBook.Application.Interfaces;
using PlayersBook.Application.ViewModels.Advertisement;
using PlayersBook.Application.ViewModels.PlayerProfile;
using PlayersBook.Domain.Entities;

namespace PlayersBook.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class PlayerProfileController : ControllerBase
    {
        private readonly IPlayerProfileService playerProfileService;
        private readonly IFileService fileService;
        private readonly ILogger<PlayerProfileController> logger;
        private readonly IMapper mapper;

        public PlayerProfileController(IPlayerProfileService playerProfileService, IFileService fileService, ILogger<PlayerProfileController> logger, IMapper mapper)
        {
            this.playerProfileService = playerProfileService;
            this.fileService = fileService;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            logger.LogInformation($"Method: {nameof(GetAllAsync)} -- Controller: {nameof(PlayerProfileController)}");

            var result = mapper.Map<List<PlayerProfileAllViewModel>>(await playerProfileService.GetallAsync());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            logger.LogInformation($"Method: {nameof(GetByIdAsync)} -- Controller: {nameof(PlayerProfileController)}");

            var result = mapper.Map<PlayerProfileDetailViewModel>(await playerProfileService.GetByIdAsync(id)); 
            return Ok(result); 
        }

        [HttpPost("uploadprofilepicture/{playerid}")]
        public async Task<IActionResult> PostImagePlayerProfile(List<IFormFile> files, string playerid)
        {
            try
            {
                if (files.Count > 0)
                {
                    
                    return Ok(await fileService.SaveFilesAsync(files.FirstOrDefault(), playerid));
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostPlayerProfile(NewPlayerProfileViewModel newPlayerProfile)
        {
            try
            {
                PlayerProfile playerProfile = mapper.Map<PlayerProfile>(newPlayerProfile);

                var result = mapper.Map<PlayerProfileDetailViewModel>(await playerProfileService.PostNewPlayerProfileAsync(playerProfile));

                return Ok(result); 
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutPlayerProfile(UpdatePlayerProfileViewModel updatePlayerProfileViewModel)
        {
            try
            {
                PlayerProfile playerProfile = mapper.Map<PlayerProfile>(updatePlayerProfileViewModel);

                var result = mapper.Map<PlayerProfileDetailViewModel>(await playerProfileService.PutUpdatePlayerProfileAsync(playerProfile));

                return Ok(result); 
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

    }
}
