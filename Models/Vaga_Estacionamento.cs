using System.ComponentModel.DataAnnotations;

namespace Mottu.Models
{
    public class Vaga_Estacionamento
    {
        [Key]
        public int Id_Vaga { get; set; }

        [Required]
        public int Numero_Vaga { get; set; }

        [Required]
        public int Id_Status { get; set; }

        public Status_Vaga Status { get; set; } = new Status_Vaga();

        [Required]
        public int Id_Filial { get; set; }

        public Filial? Filial_Referencia { get; set; }
    }
}