using Microsoft.AspNetCore.Mvc;
using app_demo3.Data;
using app_demo3.Model;

namespace app_demo3.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class ProductoController : Controller
    {
        //Declarar la variable global con el tipo de la interface
        private IProducto _producto;

        //Inyectar al constructor la interface
        public ProductoController(IProducto producto)
        {
            _producto = producto;
        }

        //metodo que devuelve la lista de productos
        [HttpGet]
        public async Task<IActionResult> ListarProducto()
        {
            return Ok(await _producto.ListarProducto());
        }

        //metodo que devuelve la informacion de un producto
        [HttpGet("{id}")]
        public async Task<IActionResult> MostrarProducto(String id)
        {
            return Ok(await _producto.MostrarProducto(id));
        }

        //metodo que registra un producto
        [HttpPost]
        public async Task<IActionResult> RegistrarProducto([FromBody] Producto producto)
        {
            if (producto == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var registro = await _producto.RegistrarProducto(producto);

            return Created("Producto registrado...", registro);
        }

        //metodo que actualiza un producto
        [HttpPut]
        public async Task<IActionResult> ActualizarProducto([FromBody] Producto producto)
        {
            if (producto == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var registro = await _producto.ActualizarProducto(producto);

            return Created("Producto actualizado...", registro);
        }

        //metodo que elimina un producto
        [HttpDelete]

        public async Task<IActionResult> EliminarProducto(String id)
        {
            var registro = await _producto.EliminarProducto(id);

            return Created("Producto eliminado...", registro);
        }
    }
}
