using BarracaDonaMaria.Domain.Entities;
using BarracaDonaMaria.Domain.Repositories;
using BarracaDonaMaria.Domain.Specifications.Clientes;
using Microsoft.AspNetCore.Mvc;

namespace BarracaDonaMaria.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
    private readonly IClienteRepository clienteRepository;

    public ClientesController(IClienteRepository clienteRepository) =>
        this.clienteRepository = clienteRepository;

    [HttpGet]
    public async Task<ActionResult<IList<Cliente>>> Get() =>
        (await clienteRepository.FindAll()).ToList();

    [HttpGet("{id}")]
    public async Task<ActionResult<Cliente>> GetById(int id)
    {
        var cliente = await clienteRepository.FindById(id);

        return cliente is null
            ? NotFound() 
            : Ok(cliente);
    }

    [HttpPost]
    public async Task<ActionResult> Post(Cliente cliente)
    {
        var registerService = new ClienteRegistrationValidationService(cliente);

        if (!registerService.Validate())
        {
            return StatusCode(422, registerService.InvalidResponses());
        }
        await clienteRepository.Add(cliente);
        return Ok(cliente);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var cliente = await clienteRepository.FindById(id);

        if (cliente is null)
        {
            return NotFound();
        }
        await clienteRepository.Remove(cliente);
        return Ok(cliente);
    }

    [HttpPut]
    public async Task<ActionResult> Update(Cliente cliente)
    {
        var registerService = new ClienteRegistrationValidationService(cliente);

        if (!registerService.Validate())
        {
            return StatusCode(422, registerService.InvalidResponses());
        }
        await clienteRepository.Update(cliente);
        return Ok(cliente);
    }
}
