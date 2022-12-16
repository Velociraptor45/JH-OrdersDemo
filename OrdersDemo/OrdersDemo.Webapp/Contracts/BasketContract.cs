namespace OrdersDemo.Webapp.Contracts;
public class BasketContract
{
    public BasketContract(int id, IEnumerable<BasketItemContract> items, DateTimeOffset? finishedAt)
    {
        Id = id;
        Items = items;
        FinishedAt = finishedAt;
    }

    public int Id { get; }
    public IEnumerable<BasketItemContract> Items { get; }
    public DateTimeOffset? FinishedAt { get; }
}
