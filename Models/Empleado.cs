using System.ComponentModel.DataAnnotations;

namespace SistemaGestionConstructora.Models
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Correo { get; set; }

        public decimal Salario { get; set; }

        public string Categoria { get; set; } // Administrador, Operario, Peón
    }
}
