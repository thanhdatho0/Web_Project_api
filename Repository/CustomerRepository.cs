using api.Data;
using api.DTOs.Customer;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class CustomerRepository(ApplicationDbContext dbContext) : ICustomerRepository
{
    public async Task<List<Customer>> GetAllAsync()
    {
        return await dbContext.Customers.ToListAsync();
    }

    public async Task<Customer?> GetByIdAsync(int id)
    {
        return await dbContext.Customers.FindAsync(id) ?? null;
    }

    public async Task<Customer?> CreateAsync(Customer customer)
    {
        await dbContext.Customers.AddAsync(customer);
        await dbContext.SaveChangesAsync();
        return customer;
    }

    public async Task<Customer?> UpdateAsync(int id, CustomerUpdateDto customerUpdateDto)
    {
        var customer = await dbContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
        if (customer == null) return null;

        customer.FirstName = customerUpdateDto.FirstName;
        customer.LastName = customerUpdateDto.LastName;
        customer.Male = customerUpdateDto.Male;
        customer.PhoneNumber = customerUpdateDto.PhoneNumber;
        customer.Address = customerUpdateDto.Address;
        customer.DateOfBirth = customerUpdateDto.DateOfBirth;
        customer.Email = customerUpdateDto.Email;
        await dbContext.SaveChangesAsync();
        return customer;
    }
    //
    // public async Task<Customer?> DeleteAsync(int id)
    // {
    //     throw new NotImplementedException();
    // }
}