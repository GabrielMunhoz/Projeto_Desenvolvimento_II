using PlayersBook.Application.AutoMapper;

namespace PlayersBook.Web.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(AdvertisementMapping),
                typeof(PlayerMapping),
                typeof(GamesCategoryMapping)
                );
        }
    }
}
