using System.ComponentModel.DataAnnotations;


namespace Mottu.Models 
{
    public class Moto
    {
        [Key]
        public int Id_Moto { get; set; }

        [Required]
        public string Placa { get; set; } = string.Empty;

        [Required]
        public string Modelo { get; set; } = string.Empty;

        [Required]
        public int Ano { get; set; }

        [Required]
        public string Status_Atual { get; set; } = string.Empty;

        public int? Id_Sensor { get; set; }
        public Sensor_IoT? Sensor { get; set; }

        public int? Id_Filial { get; set; }
        public Filial? Filial { get; set; }
    } 
} 