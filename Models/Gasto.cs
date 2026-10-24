using System.ComponentModel.DataAnnotations;

namespace ApiGastos.Models;

public class Gasto
{
    public int Id {get; set;}
    
    [Required]
    [StringLength(100, ErrorMessage = "Máximo de 100 caracteres")]
    public string? Descricao {get; set;}
    
    [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero")]
    public Decimal Valor {get; set;}
    
    public DateTime Data {get; set;}
    
    public string? Categoria {get; set;}
    
    
}