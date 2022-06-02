using BarracaDonaMaria.Domain.Entities;
using BarracaDonaMaria.Domain.Repositories;
using BarracaDonaMaria.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace BarracaDonaMaria.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PedidosController : ControllerBase
{
    private readonly IPedidoRepository pedidoRepository;

    public PedidosController(IPedidoRepository pedidoRepository) =>
        this.pedidoRepository = pedidoRepository;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pedido>>> Get()
    {
        var pedidos = (await pedidoRepository.FindAll()).ToList();
        foreach (var pedido in pedidos)
        {
            pedido.Total = pedido.Items.Sum(i => i.Valor);
        }
        return Ok(pedidos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Pedido>> GetById(int id)
    {
        var pedido = await pedidoRepository.FindById(id);
        if (pedido is null)
        {
            return NotFound();
        }
        pedido.Total = pedido.Items.Sum(i => i.Valor);
        return Ok(pedido);
    }

    [HttpPost]
    public async Task<ActionResult> Post(Pedido pedido)
    {
        pedido.Total = pedido.Items.Sum(i => i.Valor);

        await pedidoRepository.Add(pedido);
        return Ok(pedido);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var pedido = await pedidoRepository.FindById(id);

        if (pedido is null)
        {
            return NotFound();
        }
        await pedidoRepository.Remove(pedido);
        return Ok(pedido);
    }

    [HttpPut]
    public async Task<ActionResult> Update(Pedido pedido)
    {
        pedido.Total = pedido.Items.Sum(i => i.Valor);
        await pedidoRepository.Update(pedido);
        return Ok(pedido);
    }
}
