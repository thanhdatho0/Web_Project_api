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
            PersonalInfo = new CustomerPersonalInfo
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Male = customer.Male,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address,
                DateOfBirth = customer.DateOfBirth,
            },
            Email = customer.Email,
            Avatar = customer.Avatar,
        };
    }

    public static Customer ToCustomerCreateDto(this CustomerCreateDto customerCreateDto)
    {
        return new Customer
        {
            FirstName = customerCreateDto.PersonalInfo.FirstName,
            LastName = customerCreateDto.PersonalInfo.LastName,
            Male = customerCreateDto.PersonalInfo.Male,
            PhoneNumber = customerCreateDto.PersonalInfo.PhoneNumber,
            Address = customerCreateDto.PersonalInfo.Address,
            DateOfBirth = customerCreateDto.PersonalInfo.DateOfBirth,
            Email = customerCreateDto.Email,
        };
    }

    public static void ToCustomerUpdateDto(this Customer customer, CustomerUpdateDto customerUpdateDto)
    {
        // customer.Avatar = customerUpdateDto.Avatar;
        customer.FirstName = customerUpdateDto.PersonalInfo.FirstName;
        customer.LastName = customerUpdateDto.PersonalInfo.LastName;
        customer.Male = customerUpdateDto.PersonalInfo.Male;
        customer.PhoneNumber = customerUpdateDto.PersonalInfo.PhoneNumber;
        customer.Address = customerUpdateDto.PersonalInfo.Address;
        customer.DateOfBirth = customerUpdateDto.PersonalInfo.DateOfBirth;
        customer.Email = customerUpdateDto.Email;
    }

    public static CustomerDetailsDto ToCustomerFromLoginDto(this Customer customer)
    {
        return new CustomerDetailsDto
        {
            PersonalInfo = new CustomerPersonalInfo
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Male = customer.Male,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address,
                DateOfBirth = customer.DateOfBirth,
            },
            Email = customer.Email,
        };
    }
}