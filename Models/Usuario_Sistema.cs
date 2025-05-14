using System.ComponentModel.DataAnnotations;

namespace Mottu.Models
{
    public class Usuario_Sistema
    {
    [Required]
    public string Login { get; set; }

    [Required]
    public string Senha_Hash { get; set; }

    [Required]
    public string Perfil { get; set; }

    public Usuario_Sistema()
    {
        Login = string.Empty;   // Inicializa no construtor
        Senha_Hash = string.Empty;
        Perfil = string.Empty;
    }
    }
}