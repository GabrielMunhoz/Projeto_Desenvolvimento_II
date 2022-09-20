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

            #endregion

            #region Repositories

            services.AddScoped<IPlayerRepository, PlayerRepository>();
            
            #endregion


        }
    }
}