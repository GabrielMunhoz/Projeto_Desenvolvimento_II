using FluentValidation;
using PlayersBook.Domain.Entities;

namespace PlayersBook.Application.Validation
{
    public class AdvertisementValidation : AbstractValidator<Advertisement>
    {
        public AdvertisementValidation()
        {
            RuleFor(ad => ad).Must(ad => !string.IsNullOrEmpty(ad.GroupCategory)).WithMessage(string.Format(Resource.ATRIBUTO_OBRIGATORIO, nameof(Advertisement.GroupCategory)));
            RuleFor(ad => ad).Must(ad => !string.IsNullOrEmpty(ad.GameCategory)).WithMessage(string.Format(Resource.ATRIBUTO_OBRIGATORIO, nameof(Advertisement.GameCategory)));
            RuleFor(ad => ad).Must(ad => !string.IsNullOrEmpty(ad.PlayerHostId)).WithMessage(string.Format(Resource.ATRIBUTO_OBRIGATORIO, nameof(Advertisement.PlayerHostId)));
            RuleFor(ad => ad).Must(ad => !string.IsNullOrEmpty(ad.TagHostGame) || !string.IsNullOrEmpty(ad.LinkDiscord)).WithMessage("Tag do host ou link do discord são obrigatórios");
            RuleFor(ad => ad).Must(ad => !string.IsNullOrEmpty(ad.PlayerHostId)).WithMessage(string.Format(Resource.ATRIBUTO_OBRIGATORIO, nameof(Advertisement.PlayerHostId)));
        }
    }
}
