using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestionConstructora.Models
{
    public class Asignacion
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Empleado")]
        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }

        [ForeignKey("Proyecto")]
        public int ProyectoId { get; set; }
        public Proyecto Proyecto { get; set; }

        public DateTime FechaAsignacion { get; set; } = DateTime.Now;
    }
}
