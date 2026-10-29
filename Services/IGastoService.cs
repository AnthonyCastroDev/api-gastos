using ApiGastos.Models;

namespace ApiGastos.Services;

public interface IGastoService
{
    public Task<List<Gasto>> ReadAllAsync();
    public Task<Gasto?> ReadByIdAsync(int id);
    public Task<Gasto?> UpdateAsync(Gasto gasto, int id);
    public Task<bool> DeleteAsync(int id);
    public Task<Gasto> CreateAsync(Gasto gasto);
}