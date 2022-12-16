using Microsoft.AspNetCore.Mvc;
using OrdersDemo.Repositories;
using OrdersDemo.Webapp.Contracts;

namespace OrdersDemo.Webapp.Controllers;

[ApiController]
[Route("v1/orders")]
public class OrdersController : ControllerBase
{
    private readonly IOrdersRepository _repository;

    public OrdersController(IOrdersRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    [ProducesResponseType(typeof(BasketContract), StatusCodes.Status201Created)]
    [Route("")]
    public async Task<IActionResult> CreateBasket()
    {
        var basket = await _repository.CreateBasketAsync();

        var basketContract = new BasketContract(basket.Id, Enumerable.Empty<BasketItemContract>(), null);

        return CreatedAtAction(nameof(GetBasket), new { basketId = basketContract.Id }, basketContract);
    }

    [HttpGet]
    [ProducesResponseType(typeof(BasketContract), StatusCodes.Status200OK)]
    [Route("{basketId}")]
    public async Task<IActionResult> GetBasket(int basketId)
    {
        BasketContract basket = null; // todo

        return Ok(basket);
    }
}
