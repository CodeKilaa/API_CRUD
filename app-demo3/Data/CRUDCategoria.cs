using app_demo3.Model;
using Dapper;
using MySql.Data.MySqlClient;

namespace app_demo3.Data
{
    public class CRUDCategoria : ICategoria
    {
        private Configuracion _conexion;

        //inyectar al constructor la conexion de la clase Configuracion
        public CRUDCategoria(Configuracion conexion)
        {
            _conexion = conexion;
        }

        //Metodo para conectar
        protected MySqlConnection Conectar()
        {
            return new MySqlConnection(_conexion.Conectar);
        }

        //Metodo para listar categorias
        public async Task<IEnumerable<Categoria>> ListarCategoria()
        {
            var bd = Conectar();

            String cad_sql = @"select * from tb_categoria";

            return await bd.QueryAsync<Categoria>(cad_sql, new { });
        }

        //Metodo para mostrar la informacion de un proyecto
        public async Task<Categoria> MostrarCategoria(String id)
        {
            var bd = Conectar();

            String cad_sql = @"select * from tb_categoria where id = @idCat";

            return await bd.QueryFirstAsync<Categoria>(cad_sql, new { idCat = id });
        }

        //Metodo para registrar una categoria
        public async Task<bool> RegistrarCategoria(Categoria categoria)
        {
            var bd = Conectar();

            String cad_sql = @"insert into tb_categoria values 
                                (@idCat, @nom)";

            int n = await bd.ExecuteAsync(cad_sql, new
            {
                idCat = categoria.id,
                nom = categoria.nombre,
            });

            return n > 0;
        }

        //Metodo para actualizar una categoria
        public async Task<bool> ActualizarCategoria(Categoria categoria)
        {
            var bd = Conectar();

            String cad_sql = @"update tb_categoria set
                                nombre = @nom, where id = @idCat";

            int n = await bd.ExecuteAsync(cad_sql, new
            {
                idCat = categoria.id,
                nom = categoria.nombre,
            });

            return n > 0;
        }

        public async Task<bool> EliminarCategoria(String codigo)
        {
            var bd = Conectar();

            String cad_sql = @"delete from tb_categoria where id = @idCat";

            int n = await bd.ExecuteAsync(cad_sql, new { idCat = codigo });

            return n > 0;
        }
    }
}
