using System.ComponentModel.DataAnnotations;

namespace Mottu.Models
{
    public class Moto
    {
        [Key]
        public int Id_Moto { get; set; }

        [Required]
        public string Placa { get; set; }

        [Required]
        public string Modelo { get; set; }

        [Required]
        public int Ano { get; set; }

        [Required]
        public string Status_Atual { get; set; }

        // Construtor vazio necessário para o Entity Framework
        public Moto() { }

        // Construtor com todos os campos usados
        public Moto(int idMoto, string placa, string modelo, int ano, string statusAtual)
        {
            Id_Moto = idMoto;
            Placa = placa;
            Modelo = modelo;
            Ano = ano;
            Status_Atual = statusAtual;
        }
    }
}