using System.ComponentModel.DataAnnotations;

namespace Mottu.Models
{
    public class Filial
    {
        [Key]
    public int Id_Filial { get; set; }
    
    [Required] // Se você deseja que a propriedade nunca seja nula.
    public string Nome { get; set; } = string.Empty;  // Inicializando para evitar erro CS8618
    
    [Required]
    public string Endereco { get; set; } = string.Empty;
    
    [Required]
    public string Cidade { get; set; } = string.Empty;
    }
}