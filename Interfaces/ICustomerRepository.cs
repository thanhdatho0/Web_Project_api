using api.DTOs.Customer;
using api.Models;

namespace api.Interfaces;

public interface ICustomerRepository
{
    Task<List<Customer>> GetAllAsync();
    Task<Customer?> GetByIdAsync(string id);
    Task<Customer?> CreateAsync(Customer customer);
    Task<Customer?> UpdateAsync(string id,string baseUrl, IFormFile? file, CustomerUpdateDto customerUpdateDto);
    // Task<Customer?> DeleteAsync(int id);
}