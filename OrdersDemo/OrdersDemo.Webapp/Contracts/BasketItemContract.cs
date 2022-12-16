using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
