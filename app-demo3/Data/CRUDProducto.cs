using app_demo3.Model;
using MySql.Data.MySqlClient;
using Dapper;

namespace app_demo3.Data
{
    public class CRUDProducto : IProducto
    {
        private Configuracion _conexion;

        //inyectar al constructor la conexion de la clase Configuracion
        public CRUDProducto(Configuracion conexion)
        {
            _conexion = conexion;
        }

        //Metodo para conectar
        protected MySqlConnection Conectar()
        {
            return new MySqlConnection(_conexion.Conectar);
        }

        //Metodo para listar productos
        public async Task<IEnumerable<Producto>> ListarProducto()
        {
            var bd = Conectar();

            String cad_sql = @"select * from tb_producto";

            return await bd.QueryAsync<Producto>(cad_sql, new { });
        } 

        //Metodo para mostrar la informacion de un proyecto
        public async Task<Producto> MostrarProducto(String id)
        {
            var bd = Conectar();

            String cad_sql = @"select * from tb_producto where id = @idProd";

            return await bd.QueryFirstAsync<Producto>(cad_sql, new { idProd = id});
        }

        //Metodo para registrar un producto
        public async Task<bool> RegistrarProducto(Producto producto)
        {
            var bd = Conectar();

            String cad_sql = @"insert into tb_producto values 
                                (@idProd, @nom, @desc, @pre, @catId, @stockProd)";

            int n = await bd.ExecuteAsync(cad_sql, new
            {
                idProd = producto.id,
                nom = producto.nombre,
                desc = producto.descripcion,
                pre = producto.precio,
                catId = producto.categoria_id,
                stockProd = producto.stock
            });

            return n > 0;
        }

        //Metodo para actualizar un producto
        public async Task<bool> ActualizarProducto(Producto producto)
        {
            var bd = Conectar();

            String cad_sql = @"update tb_producto set
                                nombre = @nom, descripcion = @desc, precio = @pre, categoria_id = @catId, stock = @stk 
                                where id = @idProd";

            int n = await bd.ExecuteAsync(cad_sql, new
            {
                idProd = producto.id,
                nom = producto.nombre,
                desc = producto.descripcion,
                pre = producto.precio,
                catId = producto.categoria_id,
                stk = producto.stock
            });

            return n > 0;
        }

        public async Task<bool> EliminarProducto(String codigo)
        {
            var bd = Conectar();

            String cad_sql = @"delete from tb_producto where id = @idProd";

            int n = await bd.ExecuteAsync(cad_sql, new { idProd = codigo });

            return n > 0;
        }
    }
}
