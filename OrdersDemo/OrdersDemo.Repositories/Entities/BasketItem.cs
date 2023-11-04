using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersDemo.Repositories.Entities;
public class BasketItem
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public float Price { get; set; }
    public int BasketId { get; set; }

    [ForeignKey(nameof(BasketId))]
    public Basket? Basket { get; set; }
}
