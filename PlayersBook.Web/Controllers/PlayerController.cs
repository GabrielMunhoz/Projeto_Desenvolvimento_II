using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayersBook.Application.Interfaces;
using PlayersBook.Application.ViewModels.Player;
using PlayersBook.Domain.Entities;
using Template.Application.ViewModels;

namespace PlayersBook.Web.Controllers
{
    [ApiController,Authorize]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService playerService;
        private readonly IMapper mapper;
        private readonly ILogger<PlayerController> _logger;

        public PlayerController(IPlayerService playerService, IMapper mapper, ILogger<PlayerController> logger)
        {
            this.playerService = playerService;
            this.mapper = mapper;
            this._logger = logger;
        }

        [HttpPost("Authenticate"), AllowAnonymous]
        public IActionResult Authenticate(PlayerAuthenticateRequestViewModel playerViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Player player = mapper.Map<Player>(playerViewModel); 

            return Ok(playerService.Authenticate(player));
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation($"Method get {nameof(PlayerController)}"); 

            return Ok(mapper.Map<List<PlayerViewModel>>(playerService.Get()));
        }

        [HttpGet("validateToken")]
        public IActionResult ValidateToken()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            return Ok(mapper.Map<PlayerViewModel>(playerService.GetByIdAsync(id)));
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Post(NewPlayerViewModel playerViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Player Invalid");

            var user = mapper.Map<Player>(playerViewModel);

            return Ok(mapper.Map<PlayerViewModel>(await playerService.Post(user)));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdatePlayerViewModel playerViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await playerService.Put(mapper.Map<Player>(playerViewModel));

            return Ok(mapper.Map<PlayerViewModel>(result));
        }

    }
}
