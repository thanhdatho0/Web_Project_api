using api.DTOs.TargetCustomer;
using api.Models;

namespace api.Interfaces
{
    public interface ITargetCustomerRepository
    {
        Task<List<TargetCustomer>> GetAllAsync();
        Task<TargetCustomer?> GetByIdAsync(int id);
        Task<TargetCustomer> CreateAsync(TargetCustomer targetCustomer);
        Task<TargetCustomer?> UpdateAsync(int id, TargetCustomerUpdateDto targetCustomerUpdateDto);
        Task<TargetCustomer?> DeleteAsync(int id);
        Task<bool> TargetCustomerExists(int id);
    }
}