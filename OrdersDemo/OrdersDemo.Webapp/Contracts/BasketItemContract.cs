namespace OrdersDemo.Webapp.Contracts;
public class BasketItemContract
{
    public BasketItemContract(int id, string name, float price)
    {
        Id = id;
        Name = name;
        Price = price;
    }
    public int Id { get; }
    public string Name { get; }
    public float Price { get; }
}
