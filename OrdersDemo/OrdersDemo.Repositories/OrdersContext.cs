using Microsoft.EntityFrameworkCore;
using OrdersDemo.Repositories.Entities;

namespace OrdersDemo.Repositories;
public class OrdersContext : DbContext
{
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<BasketItem> BasketItemss { get; set; }

    public OrdersContext(DbContextOptions<OrdersContext> options) : base(options)
    {
    }
}
