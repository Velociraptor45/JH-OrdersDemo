using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersDemo.Repositories.Entities;
public class Basket
{
    public int Id { get; set; }
    public DateTimeOffset? FinishedAt { get; set; }

    [InverseProperty(nameof(BasketItem.Basket))]
    public ICollection<BasketItem> Items { get; set; } = new List<BasketItem>();
}
