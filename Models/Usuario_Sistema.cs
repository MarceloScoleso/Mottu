using System.ComponentModel.DataAnnotations;

namespace Mottu.Models
{
    public class Usuario_Sistema
    {
        [Key] // Define como chave primária
        public int ID_USUARIO { get; set; } 

        [Required]
        public string Login { get; set; }

        [Required]
        public string Senha_Hash { get; set; }

        [Required]
        public string Perfil { get; set; }

        public Usuario_Sistema()
        {
            Login = string.Empty;
            Senha_Hash = string.Empty;
            Perfil = string.Empty;
        }
    }
}