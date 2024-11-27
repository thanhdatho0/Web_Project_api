using api.DTOs.Customer;
using api.Models;

namespace api.Interfaces;

public interface ICustomerRepository
{
    Task<List<Customer>> GetAllAsync();
    Task<Customer?> GetByIdAsync(int id);
    Task<Customer?> CreateAsync(Customer customer);
    Task<Customer?> UpdateAsync(int id, CustomerUpdateDto customerUpdateDto);
    Task<Customer?> DeleteAsync(int id);
}