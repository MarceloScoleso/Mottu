using System.ComponentModel.DataAnnotations;

namespace Mottu.Models
{
    public class Movimentacao
{
    [Key]
    public int Id_Mov { get; set; }

    [Required]
    public int Id_Moto { get; set; }
    public Moto? Moto { get; set; }  // <-- nullable e sem inicialização

    [Required]
    public int Id_Vaga { get; set; }
    public Vaga_Estacionamento? Vaga { get; set; }  // <-- nullable e sem inicialização

    [Required]
    public DateTime Entrada { get; set; }

    public DateTime? Saida { get; set; }

    [Required]
    public int Id_Operador { get; set; }
    public Operador? Operador { get; set; }  // <-- nullable e sem inicialização
}
}