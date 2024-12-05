using api.DTOs.TargetCustomer;
using api.Models;

namespace api.Mappers
{
    public static class TargetCustomerMappers
    {
        public static TargetCustomerDto ToTargetCustomerDto(this TargetCustomer targetCustomerModel)
        {
            return new TargetCustomerDto
            {
                TargetCustomerId = targetCustomerModel.TargetCustomerId,
                TargetCustomerName = targetCustomerModel.TargetCustomerName,
                Url = targetCustomerModel.Url,
                Alt = targetCustomerModel.Alt,
                Categories = targetCustomerModel.Categories.Select(c => c.ToCategoryDto()).ToList()
            };
        }

        public static TargetCustomer ToTargetCustomerFromCreateDto(this TargetCustomerCreateDto targetCustomerCreateDto)
        {
            return new TargetCustomer
            {
                TargetCustomerName = targetCustomerCreateDto.TargetCustomerName,
                Url = targetCustomerCreateDto.Url,
                Alt = targetCustomerCreateDto.Alt,
            };
        }

        public static void ToTargetCustomerFromUpdateDto(this TargetCustomer targetCustomer, TargetCustomerUpdateDto targetCusUpdateDto)
        {
            targetCustomer.TargetCustomerName = targetCusUpdateDto.TargetCustomerName;
            targetCustomer.Url = targetCusUpdateDto.Url;
            targetCustomer.Alt = targetCusUpdateDto.Alt;
        }
    }
}