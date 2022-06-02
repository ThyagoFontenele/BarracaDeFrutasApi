using BarracaDonaMaria.Domain.Entities;
using BarracaDonaMaria.Domain.Repositories;
using BarracaDonaMaria.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace BarracaDonaMaria.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemPedidoController : ControllerBase
{
    private readonly IItemPedidoRepository itemPedidoRepository;

    public ItemPedidoController(IItemPedidoRepository itemPedidoRepository) =>
        this.itemPedidoRepository = itemPedidoRepository;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ItemPedido>>> Get() =>
        (await itemPedidoRepository.FindAll()).ToList();


    [HttpGet("{id}")]
    public async Task<ActionResult<ItemPedido>> GetById(int id)
    {
        var item = await itemPedidoRepository.FindById(id);

        return item is null
            ? NotFound()
            : Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult> Post(ItemPedido itemPedido)
    {
        if (itemPedido.Quantidade <= 0)
        {
            return BadRequest("Quantidade tem que ser maior que 0");
        }
        itemPedido.Valor = itemPedido.Quantidade * itemPedido.Produto.Preco;
        await itemPedidoRepository.Add(itemPedido);
        return Ok(itemPedido);

    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var itemPedido = await itemPedidoRepository.FindById(id);

        if (itemPedido is null)
        {
            return NotFound();
        }
        await itemPedidoRepository.Remove(itemPedido);
        return Ok(itemPedido);
    }

    [HttpPut]
    public async Task<ActionResult> Update(ItemPedido itemPedido)
    {
        if (itemPedido.Quantidade <= 0)
        {
            return Problem("Quantidade tem que ser maior que 0");
        }
        itemPedido.Valor = itemPedido.Quantidade * itemPedido.Produto.Preco;
        await itemPedidoRepository.Update(itemPedido);
        return Ok(itemPedido);
    }
}
