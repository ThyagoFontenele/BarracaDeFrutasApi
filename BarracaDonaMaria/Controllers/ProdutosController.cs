using BarracaDonaMaria.Domain.Entities;
using BarracaDonaMaria.Domain.Repositories;
using BarracaDonaMaria.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace BarracaDonaMaria.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoRepository produtoRepository;

    public ProdutosController(IProdutoRepository produtoRepository) =>
        this.produtoRepository = produtoRepository;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produto>>> Get() =>
        (await produtoRepository.FindAll()).ToList();

    [HttpGet("{id}")]
    public async Task<ActionResult<Produto>> GetById(int id)
    {
        var produto = await produtoRepository.FindById(id);

        return produto is null
            ? NotFound()
            : Ok(produto);
    }

    [HttpPost]
    public async Task<ActionResult> Post(Produto produto)
    {
        await produtoRepository.Add(produto);
        return Ok(produto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var produto = await produtoRepository.FindById(id);

        if (produto is null)
        {
            return NotFound();
        }
        await produtoRepository.Remove(produto);
        return Ok(produto);
    }

    [HttpPut]
    public async Task<ActionResult> Update(Produto produto)
    {
        await produtoRepository.Update(produto);
        return Ok(produto);
    }
}
