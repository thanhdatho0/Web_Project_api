using api.DTOs.Providerr;
using api.Models;

namespace api.Mappers
{
    public static class ProviderMappers
    {
        public static ProviderDto ToProviderDto(this Provider providerModel)
        {
            return new ProviderDto
            {
                ProviderId = providerModel.ProviderId,
                ProviderEmail = providerModel.ProviderEmail,
                ProviderCompanyName = providerModel.ProviderCompanyName,
                ProviderPhone = providerModel.ProviderPhone,
                Products = providerModel.ProviderProducts.Select(p => p.ToProductProviderDto()).ToList()
            };
        }

        public static Provider ToProviderFromCreateDto(this ProviderCreateDto providerCreateDto)
        {
            return new Provider
            {
                ProviderEmail = providerCreateDto.ProviderEmail,
                ProviderCompanyName = providerCreateDto.ProviderCompanyName,
                ProviderPhone = providerCreateDto.ProviderPhone
            };
        }

        public static Provider ToProviderFromUpdateDto(this ProviderUpdateDto providerUpdateDto)
        {
            return new Provider
            {
                ProviderEmail = providerUpdateDto.ProviderEmail,
                ProviderCompanyName = providerUpdateDto.ProviderCompanyName,
                ProviderPhone = providerUpdateDto.ProviderPhone
            };
        }
    }
}