using Microsoft.Extensions.DependencyInjection;
using PlayersBook.Application.Services;
using PlayersBook.Data.Repositories;
using PlayersBook.Domain.Interfaces;
using PlayersBook.Application.Interfaces;

namespace PlayersBook.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services) {


            #region Services

            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<IAdvertisementService, AdvertisementService>();
            services.AddScoped<IGamesCategoryService, GamesCategoryService>();
            services.AddScoped<IPlayerProfileService, PlayerProfileService>();
            services.AddScoped<IFileService, FileService>();

            #endregion

            #region Repositories

            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
            services.AddScoped<IGamesCategoryRepository, GamesCategoryRepository>();
            services.AddScoped<ITwitchRespository, TwitchRepository>();
            services.AddScoped<IPlayerProfileRepository, PlayerProfileRepository>();
            
            #endregion


        }
    }
}