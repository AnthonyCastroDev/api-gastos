using ApiGastos.Models;
using ApiGastos.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiGastos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GastosController : ControllerBase
{
    private readonly IGastoService _service;
    
    public GastosController(IGastoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Gasto>>> GetAll()
    {
        return Ok(await _service.ReadAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Gasto>> GetById(int id)
    {
        var gasto = await _service.ReadByIdAsync(id);
        
        if (gasto is null)
        {
            return NotFound($"O gasto com o id {id} não foi encontrado");
        }

        return Ok(gasto);
    }
    
    
    
    
    
    
    
    
    
    
    
}