using api.DTOs.TargetCustomer;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface ITargetCustomerRepository
    {
        Task<List<TargetCustomer>> GetAllAsync(TargetCustomerQuery query);
        Task<TargetCustomer?> GetByIdAsync(int id);
        Task<TargetCustomer> CreateAsync(TargetCustomer targetCustomer);
        Task<TargetCustomer?> UpdateAsync(int id, TargetCustomerUpdateDto targetCustomerUpdateDto);
        // Task<TargetCustomer?> DeleteAsync(int id);
        Task<bool> TargetCustomerExists(int id);
        Task<bool> TargetCustomerNameExists(string targetCustomerName);
    }
}