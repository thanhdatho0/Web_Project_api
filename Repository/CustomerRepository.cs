using api.Data;
using api.DTOs.Customer;
using api.Interfaces;
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
        throw new NotImplementedException();
    }

    public async Task<Customer?> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}