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
    
    
    
    
    
    
    
    
}