using System.ComponentModel.DataAnnotations;
using Mottu.Models;

namespace Mottu.Models
{
    public class Vaga_Estacionamento
{
    [Key]
    public int Id_Vaga { get; set; }

    [Required]
    public int Numero_Vaga { get; set; }

    [Required]
    public int Id_Status { get; set; } // chave estrangeira para Status_Vaga

    public Status_Vaga Status { get; set; } = new Status_Vaga(); // navegação

    [Required]
    public int Id_Filial { get; set; }

    public Filial Filial_Referencia { get; set; } = new Filial();

    // Campo auxiliar opcional
    public string Status_Vaga { get; set; } = "Disponível";

    public string Filial { get; set; } = "Filial 1";
}
}
