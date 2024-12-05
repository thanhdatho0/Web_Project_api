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
                Products = providerModel.ProviderProducts?.Select(p => p.ToProductDto()).ToList()
            };
        }

        public static Provider ToProviderFromCreateDto(this ProviderCreateDto providerCreateDto)
        {
            return new Provider
            {
                ProviderEmail = providerCreateDto.ProviderEmail!,
                ProviderCompanyName = providerCreateDto.ProviderCompanyName,
                ProviderPhone = providerCreateDto.ProviderPhone
            };
        }

        public static void ToProviderFromUpdateDto(this Provider provider, ProviderUpdateDto providerUpdateDto)
        {
            provider.ProviderEmail = providerUpdateDto.ProviderEmail;
            provider.ProviderCompanyName = providerUpdateDto.ProviderCompanyName;
            provider.ProviderPhone = providerUpdateDto.ProviderPhone;
        }
    }
}