using empleados.API.Models;
using Microsoft.EntityFrameworkCore;

namespace empleados.API.Data
{
    public class empleadoDBcontex : DbContext
    {
        public empleadoDBcontex(DbContextOptions options) : base(options)
        {
        }

        //Dbset
        public DbSet<empleado> empleados { get; set; }
    }
}
