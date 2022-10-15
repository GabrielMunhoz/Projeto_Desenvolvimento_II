using AutoMapper;
using PlayersBook.Application.ViewModels.Advertisement;
using PlayersBook.Application.ViewModels.GamesCategory;
using PlayersBook.Domain.DTOs;
using PlayersBook.Domain.Entities;
using Profile = AutoMapper.Profile;

namespace PlayersBook.Application.AutoMapper
{
    public class GamesCategoryMapping : Profile
    {
        public GamesCategoryMapping()
        {
            #region ViewModelToDomain
            CreateMap<GamesCategoryViewModel, GamesCategory>();
            CreateMap<GamesCategoryViewModel, GamesCategoryDto>();

            #endregion

            #region DomainToViewModel
            CreateMap<GamesCategory, GamesCategoryViewModel>();
            CreateMap<GamesCategory, GamesCategoryDto>();

            #endregion
        }
    }
}
