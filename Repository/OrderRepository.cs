using api.Data;
using api.DTOs.Order;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class OrderRepository(ApplicationDbContext dbContext) : IOrderRepository
{
    public async Task<List<Order>> GetAllAsync()
    {
        var orders = 
            dbContext.Orders
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
        var order = await dbContext.Orders
            .Include(o => o.Employee)
            .Include(o => o.OrderDetails)
            .Include(o => o.Customer)
            .FirstOrDefaultAsync(o => o.OrderId == id);
        return order ?? null;
    }

    public async Task<Order> CreateAsync(Order order)
    {
        await dbContext.Orders.AddAsync(order);
        await dbContext.SaveChangesAsync();
        return order;
    }

    public async Task<Order?> UpdateAsync(int id, OrderUpdateDto orderUpdateDto)
    {
        var order = await dbContext.Orders
            .Include(o => o.Employee)
            .Include(o => o.OrderDetails)
            .Include(o => o.Customer)
            .FirstOrDefaultAsync(o => o.OrderId == id);
        if(order == null) return null;
        dbContext.Entry(order).CurrentValues.SetValues(orderUpdateDto);
        await dbContext.SaveChangesAsync();
        return order;
    }
}