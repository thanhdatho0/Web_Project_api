using api.Data;
using api.DTOs.Customer;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class CustomerRepository(ApplicationDbContext dbContext, IImageService imageService) : ICustomerRepository
{
    public Task<List<Customer>> GetAllAsync()
    {
        return dbContext.Customers.AsNoTracking().ToListAsync();
    }

    public async Task<Customer?> GetByIdAsync(int id)
    {
        return await dbContext.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.CustomerId == id) ?? null;
    }

    public async Task<Customer?> CreateAsync(Customer customer)
    {
        await dbContext.Customers.AddAsync(customer);
        await dbContext.SaveChangesAsync();
        return customer;
    }

    public async Task<Customer?> UpdateAsync(int id, string baseUrl, IFormFile? file, CustomerUpdateDto customerUpdateDto)
    {
        var customer = await dbContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
        if (customer == null) return null;

        customer.ToCustomerUpdateDto(customerUpdateDto);
        if (file != null)
        {
            customer.Avatar = await imageService.CreateUrlAsync(file, baseUrl);
        }
        await dbContext.SaveChangesAsync();
        return customer;
    }
}