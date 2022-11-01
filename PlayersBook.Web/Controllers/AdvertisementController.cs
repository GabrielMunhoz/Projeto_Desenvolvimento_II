using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PlayersBook.Application.Interfaces;
using PlayersBook.Application.ViewModels.Advertisement;
using PlayersBook.Domain.Entities;

namespace PlayersBook.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class AdvertisementController : ControllerBase
    {
        private readonly IAdvertisementService advertisementService;
        private readonly IMapper mapper;
        private readonly ILogger<AdvertisementController> logger;

        public AdvertisementController(IAdvertisementService advertisementService, 
            IMapper mapper, ILogger<AdvertisementController> logger)
        {
            this.advertisementService = advertisementService;
            this.mapper = mapper;
            this.logger = logger;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAdvertisementsAsync()
        {
            return Ok(mapper.Map<List<AdvertisementViewModel>>(await advertisementService.GetAllAsync())); 
        }
        
        [HttpGet("advertisementsGrouped")]
        public async Task<IActionResult> GetAdvertisementsGrouByCategorysAsync()
        {
            var itemsGrouped = mapper.Map<List<AdvertisementGroupedViewModel>>(await advertisementService.GetAdvertisementsGroupedAsync()); 

            return Ok(JsonConvert.SerializeObject(itemsGrouped)); 
        }

        [HttpGet("advertisementsGroupedWithArt"), AllowAnonymous]
        public async Task<IActionResult> GetAdvertisementsGrouByCategorysWithArtAsync()
        {
            var itemsGrouped = mapper.Map<List<AdvertisementGroupedWithArtViewModel>>(await advertisementService.GetAdvertisementsGroupedWithArtAsync()); 

            return Ok(itemsGrouped); 
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var result = mapper.Map<AdvertisementDetailViewModel>(await advertisementService.GetById(id)); 

            return Ok(result); 
        }

        [HttpGet("getDetailed/{id}")]
        public async Task<IActionResult> GetByIdReferenceAsync(string id)
        {
            var result = mapper.Map<AdvertisementViewModel>(await advertisementService.GetById(id));

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAdvertisementsAsync(NewAdvertisementViewModel newAdvertisementViewModel)
        {
            var advertisement = mapper.Map<Advertisement>(newAdvertisementViewModel);
            var result = mapper.Map<AdvertisementViewModel>(await advertisementService.PostAsync(advertisement));
            return Ok( result); 
        }
        
        [HttpPut]
        public async Task<IActionResult> PutAdvertisementsAsync(UpdateAdvertisementViewModel UpdateAdvertisementViewModel)
        {
            var advertisement = mapper.Map<Advertisement>(UpdateAdvertisementViewModel);

            var result = mapper.Map<AdvertisementViewModel>(await advertisementService.PutAsync(advertisement));

            return Ok(result); 
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdvertisementsAsync(string id)
        {
            return Ok(await advertisementService.DeleteAsync(id));
        }

    }
}
