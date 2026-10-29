using ApiGastos.Data;
using ApiGastos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiGastos.Services;

public class GastoService : IGastoService
{
   private readonly AppDbContext _dbContext;

   public GastoService(AppDbContext dbContext)
   {
      _dbContext = dbContext;
   }

   public async Task<List<Gasto>> ReadAllAsync()
   {
      return await _dbContext.Gastos.ToListAsync();
   }

   public async Task<Gasto?> ReadByIdAsync(int id)
   {
      return await _dbContext.Gastos.FirstOrDefaultAsync(g=> g.Id == id);
   }

   public async Task<Gasto?> UpdateAsync(Gasto gasto, int id)
   {
      var gastoExistente = await _dbContext.Gastos.FirstOrDefaultAsync(g=> g.Id == id);
      
      if(gastoExistente is null)
      {
         return null;
      }
      
      gastoExistente.Data = gasto.Data;
      gastoExistente.Categoria = gasto.Categoria;
      gastoExistente.Descricao = gasto.Descricao;
      gastoExistente.Valor = gasto.Valor;
      
      await _dbContext.SaveChangesAsync();
      return gastoExistente;
   }

   public async Task<bool> DeleteAsync(int id)
   {
      var gastoExistente = await _dbContext.Gastos.FirstOrDefaultAsync(g => g.Id == id);
      
      if(gastoExistente is null)
      {
         return false;
      }
      
      _dbContext.Gastos.Remove(gastoExistente);
      await _dbContext.SaveChangesAsync();
      return true;
   }

   public async Task<Gasto> CreateAsync(Gasto gasto)
   {
      _dbContext.Gastos.Add(gasto);
      await _dbContext.SaveChangesAsync();
      return gasto;
   }
   
}