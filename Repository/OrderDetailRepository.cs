using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class OrderDetailRepository(ApplicationDbContext dbContext) : IOrderDetailRepository
{
    public async Task<List<OrderDetail>> GetAllAsync()
    {
        var orderDetails = 
            dbContext.OrderDetails
                .Include(o => o.Order)
                .Include(o => o.Inventory!.Product)
                .Include(o => o.Inventory!.Size)
                .Include(o => o.Inventory!.Color);
        return await orderDetails.ToListAsync();
    }

    public async Task<OrderDetail?> GetByIdAsync(int id)
    {
        var orderDetail = await dbContext.OrderDetails.FindAsync(id);
        return orderDetail ?? null;
    }

    public async Task<OrderDetail> CreateAsync(OrderDetail orderDetail)
    {
        var product = await dbContext.Products.FindAsync(orderDetail.Inventory!.ProductId);
        product!.InStock -= orderDetail.Amount;
        await dbContext.OrderDetails.AddAsync(orderDetail);
        await dbContext.SaveChangesAsync();
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