using Microsoft.EntityFrameworkCore;
using OrdersDemo.Repositories.Entities;

namespace OrdersDemo.Repositories;
public class OrdersRepository : IOrdersRepository
{
    private readonly OrdersContext _dbContext;

    public OrdersRepository(OrdersContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddItemToBasketAsync(int basketId, string itemName, float itemPrice)
    {
        var basket = await FindBasketByAsync(basketId);
        if (basket is null)
            throw new InvalidOperationException($"No basket with id {basketId} found");
        if (basket.FinishedAt is not null)
            throw new InvalidOperationException("It's not allowed to edit a finished basket");
        
        var item = new BasketItem
        {
            Name = itemName,
            Price = itemPrice,
            BasketId = basketId
        };

        await _dbContext.BasketItemss.AddAsync(item);
    }

    public async Task<Basket?> FindBasketByAsync(int basketId)
    {
        return await _dbContext.Baskets.FirstOrDefaultAsync(b => b.Id == basketId);
    }

    public async Task<Basket> CreateBasketAsync()
    {
        var existingBasket = await GetActiveBasket();
        if (existingBasket is not null)
            throw new InvalidOperationException($"There is already an active basket with id {existingBasket.Id}");

        var basket = new Basket();

        await _dbContext.AddAsync(basket);
        await _dbContext.SaveChangesAsync();

        return basket;
    }

    private async Task<Basket?> GetActiveBasket()
    {
        return await _dbContext.Baskets.FirstOrDefaultAsync(b => b.FinishedAt == null);
    }
}
