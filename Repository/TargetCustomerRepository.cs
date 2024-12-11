
using api.Data;
using api.DTOs.TargetCustomer;
using api.Helpers;
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
            context.TargetCustomers.Add(targetCustomer);
            await context.SaveChangesAsync();
            return targetCustomer;
        }

        public Task<TargetCustomer?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> TargetCustomerExists(int id)
        {
            return await context.TargetCustomers.AnyAsync(g => g.TargetCustomerId == id);
        }

        public async Task<bool> TargetCustomerNameExists(string targetCustomerName)
        {
            return await context.TargetCustomers.AnyAsync(g => g.TargetCustomerName == targetCustomerName);
        }

        public async Task<List<TargetCustomer>> GetAllAsync(TargetCustomerQuery query)
        {
            // return await context.TargetCustomers
            //                     .Include(t => t.Categories)
            //                     .ThenInclude(c => c.Subcategories).ToListAsync();

            var targetCustomer = context.TargetCustomers.Include(t => t.Categories).ThenInclude(c => c.Subcategories).AsQueryable();

            if (query.subcategoryId.HasValue)
            {
                targetCustomer = targetCustomer.Where(tc => tc.Categories.Any(c => c.Subcategories.Any(s => s.SubcategoryId == query.subcategoryId)));
            }

            return await targetCustomer.ToListAsync();
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