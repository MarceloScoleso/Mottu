using System.ComponentModel.DataAnnotations;

namespace Mottu.Models
{
    public class Log_Acao
    {
        [Key]
        public int Id_Log { get; set; }

        public int Id_Usuario { get; set; }
        public Usuario_Sistema? Usuario { get; set; }

        [Required]
        public string Acao_Realizada { get; set; } = string.Empty;

        public DateTime Data_Hora { get; set; } = DateTime.Now;
    }
}