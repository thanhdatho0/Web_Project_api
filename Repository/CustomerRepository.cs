using api.Data;
using api.DTOs.Customer;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CustomerRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<Customer>> GetAllAsync()
    {
        return await _dbContext.Customers.ToListAsync();
    }

    public async Task<Customer?> GetByIdAsync(int id)
    {
        return await _dbContext.Customers.FindAsync(id) ?? null;
    }

    public async Task<Customer?> CreateAsync(Customer customer)
    {
        await _dbContext.Customers.AddAsync(customer);
        await _dbContext.SaveChangesAsync();
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