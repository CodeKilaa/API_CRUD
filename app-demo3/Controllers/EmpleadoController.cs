using Microsoft.AspNetCore.Mvc;
using app_demo3.Data;
using app_demo3.Model;

namespace app_demo3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : Controller
    {
        //Declarar la variable global con el tipo de la interface
        private IEmpleado _empleado;

        //Inyectar al constructor la interface
        public EmpleadoController(IEmpleado empleado)
        {
            _empleado = empleado;
        }

        //metodo que devuelve la lista de productos
        [HttpGet]
        public async Task<IActionResult> ListarEmpleado()
        {
            return Ok(await _empleado.ListarEmpleado());
        }

        //metodo que devuelve la informacion de un producto
        [HttpGet("{id}")]
        public async Task<IActionResult> MostrarEmpleado(String id)
        {
            return Ok(await _empleado.MostrarEmpleado(id));
        }

        //metodo que registra un producto
        [HttpPost]
        public async Task<IActionResult> RegistrarEmpleado([FromBody] Empleado empleado)
        {
            if (empleado == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var registro = await _empleado.RegistrarEmpleado(empleado);

            return Created("Empleado registrado...", registro);
        }

        //metodo que actualiza un producto
        [HttpPut]
        public async Task<IActionResult> ActualizarEmpleado([FromBody] Empleado empleado)
        {
            if (empleado == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var registro = await _empleado.ActualizarEmpleado(empleado);

            return Created("Empleado actualizado...", registro);
        }

        //metodo que elimina un producto
        [HttpDelete]

        public async Task<IActionResult> EliminarEmpleado(String id)
        {
            var registro = await _empleado.EliminarEmpleado(id);

            return Created("Empleado eliminado...", registro);
        }
    }
}
