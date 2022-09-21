using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayersBook.Application.Interfaces;
using PlayersBook.Application.ViewModels.Player;
using PlayersBook.Domain.Entities;
using Template.Application.ViewModels;

namespace PlayersBook.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService playerService;
        private readonly IMapper mapper;

        public PlayerController(IPlayerService playerService, IMapper mapper)
        {
            this.playerService = playerService;
            this.mapper = mapper;
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
            return Ok(mapper.Map<List<PlayerViewModel>>(playerService.Get()));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            return Ok(mapper.Map<PlayerViewModel>(playerService.GetById(id)));
        }

        [HttpPost]
        public IActionResult Post(PlayerViewModel playerViewModel)
        {
            if (playerViewModel.Id != Guid.Empty)
                throw new Exception("Id must be empty.");

            if (ModelState.IsValid)
                return BadRequest("Player Invalid");

            var user = mapper.Map<Player>(playerViewModel);

            return Ok(playerService.Post(user));
        }

        [HttpPut]
        public IActionResult Put(PlayerViewModel playerViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = playerService.Put(mapper.Map<Player>(playerViewModel));

            return Ok(result);
        }

    }
}
