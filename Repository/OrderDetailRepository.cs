using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class OrderDetailRepository : IOrderDetailRepository
{
    private readonly ApplicationDbContext _dbContext;

    public OrderDetailRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<OrderDetail>> GetAllAsync()
    {
        var orderDetails = 
            _dbContext.OrderDetails
                .Include(o => o.Order)
                .Include(o => o.Product)
                .Include(o => o.Size)
                .Include(o => o.Color);
        return await orderDetails.ToListAsync();
    }

    public async Task<OrderDetail?> GetByIdAsync(int id)
    {
        var orderDetail = await _dbContext.OrderDetails.FindAsync(id);
        return orderDetail ?? null;
    }

    public async Task<OrderDetail> CreateAsync(OrderDetail orderDetail)
    {
        await _dbContext.OrderDetails.AddAsync(orderDetail);
        await _dbContext.SaveChangesAsync();
        return orderDetail;
    }

    public async Task<OrderDetail?> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CategoryExists(int id)
    {
        throw new NotImplementedException();
    }
}