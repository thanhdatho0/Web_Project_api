using api.DTOs.Customer;
using api.Models;

namespace api.Mappers;

public static class CustomerMappers
{
    public static CustomerDto ToCustomerDto(this Customer customer)
    {
        return new CustomerDto
        {
            FullName = customer.FullName,
            Male = customer.Male,
            PhoneNumber = customer.PhoneNumber,
            Address = customer.Address,
            DateOfBirth = customer.DateOfBirth,
            Email = customer.Email,
            Avatar = customer.Avatar,
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

    public static void ToCustomerUpdateDto(this Customer customer, CustomerUpdateDto customerUpdateDto)
    {
        customer.Avatar = customerUpdateDto.Avatar;
        customer.FirstName = customerUpdateDto.FirstName;
        customer.LastName = customerUpdateDto.LastName;
        customer.Male = customerUpdateDto.Male;
        customer.PhoneNumber = customerUpdateDto.PhoneNumber;
        customer.Address = customerUpdateDto.Address;
        customer.DateOfBirth = customerUpdateDto.DateOfBirth;
        customer.Email = customerUpdateDto.Email;
    }

    public static CustomerDetailsDto ToCustomerFromLoginDto(this Customer customer)
    {
        return new CustomerDetailsDto
        {
            FullName = customer.FirstName + " " + customer.LastName,
            Male = customer.Male,
            PhoneNumber = customer.PhoneNumber,
            Address = customer.Address,
            DateOfBirth = customer.DateOfBirth,
            Email = customer.Email,
        };
    }
}