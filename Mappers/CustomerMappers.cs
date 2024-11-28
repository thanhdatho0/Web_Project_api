using api.DTOs.Customer;
using api.Models;

namespace api.Mappers;

public static class CustomerMappers
{
    public static CustomerDto ToCustomerDto(this Customer customer)
    {
        return new CustomerDto
        {
            CustomerId = customer.CustomerId,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Male = customer.Male,
            PhoneNumber = customer.PhoneNumber,
            Address = customer.Address,
            DateOfBirth = customer.DateOfBirth,
            Email = customer.Email,
        };
    }

    public static Customer ToCustomerCreateDto(this CustomerCreateDto customerCreateDto)
    {
        return new Customer
        {
            FirstName = customerCreateDto.FirstName,
            LastName = customerCreateDto.LastName,
            Male = customerCreateDto.Male,
            PhoneNumber = customerCreateDto.PhoneNumber,
            Address = customerCreateDto.Address,
            DateOfBirth = customerCreateDto.DateOfBirth,
            Email = customerCreateDto.Email,
        };
    }

    public static Customer ToCustomerUpdateDto(this CustomerUpdateDto customerUpdateDto)
    {
        return new Customer();
    }
}