using System.ComponentModel.DataAnnotations;

namespace TallerClase.Models
{
    public class Estadio
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(150)]
        public string Direccion { get; set; }

        [MaxLength(50)]
        public string Ciudad { get; set; }

        public float Capacidad { get; set; }
    }
}
