using System.ComponentModel.DataAnnotations;

namespace Mottu.Models
{
    public class Status_Vaga
    {
        [Key]
        public int Id_Status { get; set; }
        public string? Descricao_Status { get; set; }
    }
}