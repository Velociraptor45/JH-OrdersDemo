using OrdersDemo.Repositories.Entities;

namespace OrdersDemo.Repositories;

public interface IOrdersRepository
{
    Task AddItemToBasketAsync(int basketId, string itemName, float itemPrice);
    Task<Basket?> FindBasketByAsync(int basketId);
    Task<Basket> CreateBasketAsync();
}