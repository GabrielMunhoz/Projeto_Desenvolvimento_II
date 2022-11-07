using PlayersBook.Application.ViewModels.Advertisement;
using PlayersBook.Application.ViewModels.GamesCategory;
using PlayersBook.Application.ViewModels.PlayerProfile;
using PlayersBook.Domain.Entities;
using Profile = AutoMapper.Profile;

namespace PlayersBook.Application.AutoMapper
{
    public class PlayerProfileMapping : Profile
    {
        public PlayerProfileMapping()
        {
            #region ViewModelToDomain
            CreateMap<GamesCategoryViewModel, GamesCategory>();
            CreateMap<UpdatePlayerProfileViewModel, PlayerProfile>();
            CreateMap<NewPlayerProfileViewModel, PlayerProfile>();
            CreateMap<ChannelStreamViewModel, ChannelStreams>().ReverseMap();
            

            #endregion

            #region DomainToViewModel
            CreateMap<PlayerProfile, PlayerProfileAllViewModel>();
            CreateMap<PlayerProfile, PlayerProfileDetailViewModel>();


            #endregion
        }
    }
}
