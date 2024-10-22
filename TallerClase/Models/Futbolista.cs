using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TallerClase.Models
{
    public class Futbolista
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        public string Posicion { get; set; }

        [Required]
        public int Edad { get; set; }

        [Required]
        public int IdEquipo { get; set; }

        [ForeignKey(nameof(IdEquipo))]
        public virtual Equipo? Equipo { get; set; }
    }
}
