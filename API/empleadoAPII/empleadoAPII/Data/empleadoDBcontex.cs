using empleadoAPII.models;
using Microsoft.EntityFrameworkCore;

namespace empleadoAPII.Data
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
