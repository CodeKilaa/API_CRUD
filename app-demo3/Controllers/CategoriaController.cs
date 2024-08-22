using app_demo3.Data;
using app_demo3.Model;
using Microsoft.AspNetCore.Mvc;

namespace app_demo3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : Controller
    {
        //Declarar la variable global con el tipo de la interface
        private ICategoria _categoria;

        //Inyectar al constructor la interface
        public CategoriaController(ICategoria categoria)
        {
            _categoria = categoria;
        }

        //metodo que devuelve la lista de productos
        [HttpGet]
        public async Task<IActionResult> ListarCategoria()
        {
            return Ok(await _categoria.ListarCategoria());
        }

        //metodo que devuelve la informacion de un producto
        [HttpGet("{id}")]
        public async Task<IActionResult> MostrarCategoria(String id)
        {
            return Ok(await _categoria.MostrarCategoria(id));
        }

        //metodo que registra un producto
        [HttpPost]
        public async Task<IActionResult> RegistrarCategoria([FromBody] Categoria categoria)
        {
            if (categoria == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var registro = await _categoria.RegistrarCategoria(categoria);

            return Created("Categoria registrada...", registro);
        }

        //metodo que actualiza un producto
        [HttpPut]
        public async Task<IActionResult> ActualizarCategoria([FromBody] Categoria categoria)
        {
            if (categoria == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var registro = await _categoria.ActualizarCategoria(categoria);

            return Created("Categoria actualizada...", registro);
        }

        //metodo que elimina un producto
        [HttpDelete]

        public async Task<IActionResult> EliminarCategoria(String id)
        {
            var registro = await _categoria.EliminarCategoria(id);

            return Created("Categoria eliminada...", registro);
        }
    }
}
