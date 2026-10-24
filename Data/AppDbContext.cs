using ApiGastos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiGastos.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    DbSet<Gasto> Gastos { get; set; }
}