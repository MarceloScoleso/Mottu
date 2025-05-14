using System.ComponentModel.DataAnnotations;

namespace Mottu.Models
{
    public class Operador
    {
        [Key]
        public int Id_Operador { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public string CPF { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Login { get; set; } = string.Empty;
    }
}