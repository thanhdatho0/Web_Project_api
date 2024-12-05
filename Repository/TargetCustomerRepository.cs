
using api.Data;
using api.DTOs.TargetCustomer;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class TargetCustomerRepository(ApplicationDbContext context) : ITargetCustomerRepository
    {
        public async Task<TargetCustomer> CreateAsync(TargetCustomer targetCustomer)
        {
            await context.TargetCustomers.AddAsync(targetCustomer);
            await context.SaveChangesAsync();
            return targetCustomer;
        }

        public Task<TargetCustomer?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> TargetCustomerExists(int id)
        {
            return context.TargetCustomers.AnyAsync(g => g.TargetCustomerId == id);
        }

        public async Task<List<TargetCustomer>> GetAllAsync()
        {
            return await context.TargetCustomers
                                .Include(t => t.Categories)
                                .ThenInclude(c => c.Subcategories).ToListAsync();
        }

        public async Task<TargetCustomer?> GetByIdAsync(int id)
        {
            return await context.TargetCustomers.Include(t => t.Categories).FirstOrDefaultAsync(t => t.TargetCustomerId == id);
        }

        public async Task<TargetCustomer?> UpdateAsync(int id, TargetCustomerUpdateDto targetCustomerUpdateDto)
        {
            var targetCustomer = await context.TargetCustomers.FirstOrDefaultAsync(g => g.TargetCustomerId == id);

            if (targetCustomer == null)
                return null;

            targetCustomer.ToTargetCustomerFromUpdateDto(targetCustomerUpdateDto);
            await context.SaveChangesAsync();
            return targetCustomer;
        }
    }
}