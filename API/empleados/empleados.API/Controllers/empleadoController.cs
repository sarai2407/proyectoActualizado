using empleados.API.Data;
using empleados.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace empleados.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class empleadoController : Controller
    {
        private readonly empleadoDBcontex empleadoDBcontex;

        public empleadoController(empleadoDBcontex EmpleadoDBcontex)
        {
            this.empleadoDBcontex = EmpleadoDBcontex;
        }

        // Get all Empleados
        [HttpGet]
       public async Task<IActionResult> GetAllEmpleados()
        {
            var empleados = await empleadoDBcontex.empleados.ToListAsync();
            return Ok(empleados);
        }

        // Get single Empleados
        [HttpGet]
        [Route("{id:int}")]
        [ActionName("GetEmpleado")]
        public async Task<IActionResult> GetEmpleado([FromRoute] int id)
        {
            var empleado = await empleadoDBcontex.empleados.FirstOrDefaultAsync(x => x.Id == id);

            if(empleado != null) {
                return Ok(empleado);
            }

            return NotFound("empleado no encontrado");
            
        }

        // Add Empleado
        [HttpPost]

        public async Task<IActionResult> AddEmpleado([FromBody] empleado Empleado)
        {
            Empleado.Id = 0;
            await empleadoDBcontex.empleados.AddAsync(Empleado);
            await empleadoDBcontex.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEmpleado), new { id = Empleado.Id }, Empleado);
        }

        //Updating empleado
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateEmpleado([FromRoute] int id, [FromBody] empleado Empleado)
        {
            var existingempleado = await empleadoDBcontex.empleados.FirstOrDefaultAsync(x => x.Id == id);
            if (existingempleado != null)
            {
                existingempleado.apellido = Empleado.apellido;
                existingempleado.nombre = Empleado.nombre;
                existingempleado.telefono = Empleado.telefono;
                existingempleado.correo = Empleado.correo;
                existingempleado.foto = Empleado.foto;
                existingempleado.fecha = Empleado.fecha;
                await empleadoDBcontex.SaveChangesAsync();
                return Ok(existingempleado);
            }
            
            return NotFound("empleado no encontrado");

        }


        //Delete empleado
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteEmpleado([FromRoute] int id)
        {
            var existingempleado = await empleadoDBcontex.empleados.FirstOrDefaultAsync(x => x.Id == id);
            if (existingempleado != null)
            {
                empleadoDBcontex.Remove(existingempleado);
                await empleadoDBcontex.SaveChangesAsync();
                return Ok(existingempleado);
            }

            return NotFound("empleado no encontrado");

        }



    }
}
