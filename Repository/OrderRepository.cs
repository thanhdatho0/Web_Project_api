using api.Data;
using api.DTOs.Order;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class OrderRepository : IOrderRepository
{
    private ApplicationDbContext _dbContext;

    public OrderRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<Order>> GetAllAsync()
    {
        var orders = 
            _dbContext.Orders
                .Include(o => o.Employee)
                .Include(o => o.OrderDetails)!
                .ThenInclude(o => o.Product)
                .Include(o => o.OrderDetails)!
                .ThenInclude(o => o.Color)
                .Include(o => o.OrderDetails)!
                .ThenInclude(o => o.Size)
                .Include(o => o.Customer);
        return await orders.ToListAsync();
    }

    public async Task<Order?> GetByIdAsync(int id)
    {
        var order = await _dbContext.Orders
            .Include(o => o.Employee)
            .Include(o => o.OrderDetails)
            .Include(o => o.Customer)
            .FirstOrDefaultAsync(o => o.OrderId == id);
        return order ?? null;
    }

    public async Task<Order> CreateAsync(Order order)
    {
        await _dbContext.Orders.AddAsync(order);
        await _dbContext.SaveChangesAsync();
        return order;
    }

    public async Task<Order?> UpdateAsync(int id, OrderUpdateDto orderUpdateDto)
    {
        var order = await _dbContext.Orders
            .Include(o => o.Employee)
            .Include(o => o.OrderDetails)
            .Include(o => o.Customer)
            .FirstOrDefaultAsync(o => o.OrderId == id);
        if(order == null) return null;
        _dbContext.Entry(order).CurrentValues.SetValues(orderUpdateDto);
        await _dbContext.SaveChangesAsync();
        return order;
    }
}