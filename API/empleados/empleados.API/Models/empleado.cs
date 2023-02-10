using System.ComponentModel.DataAnnotations;

namespace empleados.API.Models
{
    public class empleado
    {
        [Key]
        public int Id { get; set; }

        public string apellido { get; set; }
        
        public string nombre { get; set; }

        public int telefono { get; set; }

        public string correo { get; set; }

        public string foto { get; set; }

        public string fecha { get; set; }

    }
}
