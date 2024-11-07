
using api.Data;
using api.DTOs.Providerr;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly ApplicationDbContext _context;

        public ProviderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Provider> CreateAsync(Provider provider)
        {
            await _context.Providers.AddAsync(provider);
            await _context.SaveChangesAsync();
            return provider;
        }

        public async Task<Provider?> DeleteAsync(int id)
        {
            var provider = await _context.Providers.FirstOrDefaultAsync(x => x.ProviderId == id);
            if (provider == null) return null;
            _context.Providers.Remove(provider);
            await _context.SaveChangesAsync();
            return provider;
        }

        public async Task<List<Provider>> GetAllAsyns()
        {
            return await _context.Providers.Include(p => p.ProviderProducts).ToListAsync();
        }

        public async Task<Provider?> GetByIdAsync(int id)
        {
            return await _context.Providers.Include(c => c.ProviderProducts).FirstOrDefaultAsync(i => i.ProviderId == id);

        }

        public Task<bool> ProviderExists(int id)
        {
            return _context.Providers.AnyAsync(p => p.ProviderId == id);
        }

        public async Task<Provider?> UpdateAsync(int id, ProviderUpdateDto providerUpdateDto)
        {
            var provider = await _context.Providers.FirstOrDefaultAsync(x => x.ProviderId == id);
            if (provider == null) return null;
            provider.ProviderCompanyName = providerUpdateDto.ProviderCompanyName;
            provider.ProviderEmail = providerUpdateDto.ProviderEmail;
            provider.ProviderPhone = providerUpdateDto.ProviderPhone;
            await _context.SaveChangesAsync();
            return provider;
        }
    }
}