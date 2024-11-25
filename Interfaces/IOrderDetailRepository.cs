using api.Models;

namespace api.Interfaces;

public interface IOrderDetailRepository
{
    Task<List<OrderDetail>> GetAllAsync();
    Task<OrderDetail?> GetByIdAsync(int id);
    Task<OrderDetail> CreateAsync(OrderDetail orderDetail);
    Task<OrderDetail?> DeleteAsync(int id);
    Task<bool> CategoryExists(int id);
}