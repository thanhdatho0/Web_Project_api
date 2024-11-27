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
                Categories = targetCustomerModel.Categories?.Select(c => c.ToCategoryDto()).ToList()
            };
        }

        public static TargetCustomer ToTargetCustomerFromCreateDto(this TargetCustomerCreateDto targetCustomerCreateDto)
        {
            return new TargetCustomer
            {
                TargetCustomerName = targetCustomerCreateDto.TargetCustomerName,
            };
        }

        public static TargetCustomer ToTargetCustomerFromUpdateDto(this TargetCustomerUpdateDto targerCusUpdateDto)
        {
            return new TargetCustomer
            {
                TargetCustomerName = targerCusUpdateDto.TargetCustomerName,
                Url = targerCusUpdateDto.Url,
                Alt = targerCusUpdateDto.Alt,
            };
        }
    }
}