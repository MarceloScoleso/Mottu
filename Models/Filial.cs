using System.ComponentModel.DataAnnotations;

namespace Mottu.Models
{
    public class Filial
    {
        [Key]
    public int Id_Filial { get; set; }
    
    [Required] 
    public string Nome { get; set; } = string.Empty;  
    
    [Required]
    public string Endereco { get; set; } = string.Empty;
    
    [Required]
    public string Cidade { get; set; } = string.Empty;
    }
}