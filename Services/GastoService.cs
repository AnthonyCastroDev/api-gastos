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
      throw new NotImplementedException();
   }

   public async Task<Gasto> UpdateAsync(Gasto gasto, int id)
   {
      throw new NotImplementedException();
   }

   public async Task<bool> DeleteAsync(int id)
   {
      throw new NotImplementedException();
   }

   public async Task CreateAsync()
   {
      throw new NotImplementedException();
   }
}