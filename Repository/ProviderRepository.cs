
using api.Data;
using api.DTOs.Providerr;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ProviderRepository(ApplicationDbContext context) : IProviderRepository
    {
        public async Task<Provider> CreateAsync(Provider provider)
        {
            await context.Providers.AddAsync(provider);
            await context.SaveChangesAsync();
            return provider;
        }

        public async Task<Provider?> DeleteAsync(int id)
        {
            var provider = await context.Providers.FirstOrDefaultAsync(x => x.ProviderId == id);
            if (provider == null) return null;
            context.Providers.Remove(provider);
            await context.SaveChangesAsync();
            return provider;
        }

        public async Task<List<Provider>> GetAllAsync()
        {
            return await context.Providers.Include(p => p.ProviderProducts).ToListAsync();
        }

        public async Task<Provider?> GetByIdAsync(int id)
        {
            return await context.Providers.Include(c => c.ProviderProducts).FirstOrDefaultAsync(i => i.ProviderId == id);

        }

        public Task<bool> ProviderExists(int id)
        {
            return context.Providers.AnyAsync(p => p.ProviderId == id);
        }

        public async Task<Provider?> UpdateAsync(int id, ProviderUpdateDto providerUpdateDto)
        {
            var provider = await context.Providers.FirstOrDefaultAsync(x => x.ProviderId == id);
            if (provider == null) return null;
            provider.ProviderCompanyName = providerUpdateDto.ProviderCompanyName;
            provider.ProviderEmail = providerUpdateDto.ProviderEmail;
            provider.ProviderPhone = providerUpdateDto.ProviderPhone;
            await context.SaveChangesAsync();
            return provider;
        }
    }
}