using System.ComponentModel.DataAnnotations;

namespace Mottu.Models
{
    public class Moto
    {
        [Key]
        public int Id_Moto { get; set; }  // Chave primária
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Status_Atual { get; set; }

        public Moto() { }

        public Moto(int idMoto, string placa, string modelo, string statusAtual)
        {
            Id_Moto = idMoto;
            Placa = placa;
            Modelo = modelo;
            Status_Atual = statusAtual;
        }
    }
}