using AutoMapper;
using PlayersBook.Application.ViewModels.Advertisement;
using PlayersBook.Domain.Entities;
using Profile = AutoMapper.Profile;

namespace PlayersBook.Application.AutoMapper
{
    public class AdvertisementMapping : Profile
    {
        public AdvertisementMapping()
        {
            #region ViewModelToDomain
            CreateMap<NewAdvertisementViewModel, Advertisement>();
            CreateMap<AdvertisementViewModel, Advertisement>();
            CreateMap<UpdateAdvertisementViewModel, Advertisement>();
            #endregion

            #region DomainToViewModel
            CreateMap<AdvertisementPlayers, PlayerReferenceViewModel>();
            CreateMap<PlayerReferenceViewModel, AdvertisementPlayers>();
            CreateMap<Advertisement, AdvertisementViewModel>()
                .ForMember(
                x => x.GuestCount,
                opt => opt.MapFrom(src => src.Guests.Count())); ;
            CreateMap<Advertisement, AdvertisementDetailViewModel>()
                .ForMember(
                x => x.Guests,
                opt => opt.MapFrom(x => x.Guests.Select(src => src.Player).ToList()))
                .ForMember(
                x => x.GuestCount,
                opt => opt.MapFrom(
                    src => src.Guests.Count()));

            #endregion
        }
    }
}
