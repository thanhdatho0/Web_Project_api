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
                .Include(o => o.OrderDetails)
                .ThenInclude(o => o.Inventory)
                .ThenInclude(i => i!.Product)
                .Include(o => o.OrderDetails)
                .ThenInclude(o => o.Inventory)
                .ThenInclude(i => i!.Color)
                .Include(o => o.OrderDetails)
                .ThenInclude(o => o.Inventory)
                .ThenInclude(i => i!.Size)
                .Include(o => o.Customer);
        return await orders.ToListAsync();
    }

    public async Task<Order?> GetByIdAsync(int id)
    {
        var order = await dbContext.Orders
                .Include(o => o.Employee)
                .Include(o => o.OrderDetails)
                .ThenInclude(o => o.Inventory)
                .ThenInclude(i => i!.Product)
                .Include(o => o.OrderDetails)
                .ThenInclude(o => o.Inventory)
                .ThenInclude(i => i!.Color)
                .Include(o => o.OrderDetails)
                .ThenInclude(o => o.Inventory)
                .ThenInclude(i => i!.Size)
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

    public async Task<List<Order>?> GetByCustomerIdAsync(int customerId)
    {
        var order = await dbContext.Orders
            .Include(o => o.Employee)
            .Include(o => o.OrderDetails)
            .ThenInclude(o => o.Inventory)
            .ThenInclude(i => i!.Product)
            .Include(o => o.OrderDetails)
            .ThenInclude(o => o.Inventory)
            .ThenInclude(i => i!.Color)
            .Include(o => o.OrderDetails)
            .ThenInclude(o => o.Inventory)
            .ThenInclude(i => i!.Size)
            .Where(o => o.CustomerId == customerId).ToListAsync();
        return order;
    }

    public async Task<Order?> ConfirmOrder(int id)
    {
        var order = await dbContext.Orders.FirstOrDefaultAsync(o => o.OrderId == id);
        if (order == null) return null;
        order.Confirmed = true;
        await dbContext.SaveChangesAsync();
        return order;
    }
}