using System.ComponentModel.DataAnnotations;

namespace Mottu.Models
{
    public class Sensor_IoT
    {
        [Key]
        public int Id_Sensor { get; set; }
        public string? Codigo_Tag { get; set; }
        public DateTime Data_Ativacao { get; set; }
    }
}