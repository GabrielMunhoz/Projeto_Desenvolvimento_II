using Microsoft.Extensions.DependencyInjection;
using PlayersBook.Application.Services;
using PlayersBook.Data.Repositories;
using PlayersBook.Domain.Interfaces;
using PlayersBook.Application.Interfaces;
using PlayersBook.Data.Repositories.Base;

namespace PlayersBook.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services) {


            #region Services

            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<IAdvertisementService, AdvertisementService>();
            services.AddScoped<IGamesCategoryService, GamesCategoryService>();

            #endregion

            #region Repositories

            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
            services.AddScoped<IGamesCategoryRepository, GamesCategoryRepository>();
            services.AddScoped<ITwitchRespository, TwitchRepository>();
            
            #endregion


        }
    }
}