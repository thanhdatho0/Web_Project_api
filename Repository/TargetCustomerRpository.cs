
using api.Data;
using api.DTOs.TargetCustomer;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class TargetCustomerRpository : ITargetCustomerRepository
    {
        private readonly ApplicationDbContext _context;
        public TargetCustomerRpository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TargetCustomer> CreateAsync(TargetCustomer targetCustomer)
        {
            await _context.TargetCustomers.AddAsync(targetCustomer);
            await _context.SaveChangesAsync();
            return targetCustomer;
        }

        public Task<TargetCustomer?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> TargetCustomerExists(int id)
        {
            return _context.TargetCustomers.AnyAsync(g => g.TargetCustomerId == id);
        }

        public async Task<List<TargetCustomer>> GetAllAsync()
        {
            return await _context.TargetCustomers.Include(t => t.Categories).ThenInclude(c => c.Subcategories).ToListAsync();
        }

        public async Task<TargetCustomer?> GetByIdAsync(int id)
        {
            return await _context.TargetCustomers.Include(t => t.Categories).FirstOrDefaultAsync(t => t.TargetCustomerId == id);
        }

        public async Task<TargetCustomer?> UpdateAsync(int id, TargetCustomerUpdateDto targetCustomerUpdateDto)
        {
            var targetCustomer = await _context.TargetCustomers.FirstOrDefaultAsync(g => g.TargetCustomerId == id);

            if (targetCustomer == null)
                return null;

            targetCustomer.TargetCustomerName = targetCustomerUpdateDto.TargetCustomerName;

            await _context.SaveChangesAsync();

            return targetCustomer;
        }
    }
}