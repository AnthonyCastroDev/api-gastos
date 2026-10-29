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

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Gasto gasto)
    {
        await _service.CreateAsync(gasto);
        return Ok(gasto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var deletou = await _service.DeleteAsync(id);

        if (!deletou)
        { 
            return NotFound($"O id {id} não foi encontrado");
        }
        
         return NoContent();
    }
    
    
    
    
    
    
    
    
    
    
    
}