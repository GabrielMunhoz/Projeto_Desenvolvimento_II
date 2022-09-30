﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayersBook.Application.Interfaces;
using PlayersBook.Application.ViewModels.Advertisement;
using PlayersBook.Data.Repositories;
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
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var result = mapper.Map<AdvertisementDetailViewModel>(await advertisementService.GetById(id)); 

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
