using System.ComponentModel.DataAnnotations;

namespace TallerClase.Models
{
    public class Equipo
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]       
        public string Nombre { get; set; }

        [MaxLength(100)]
        public string Ciudad { get; set; }

        public int Titulos { get; set; }

        public bool AceptaExtranjeros { get; set; } 
    }
}
