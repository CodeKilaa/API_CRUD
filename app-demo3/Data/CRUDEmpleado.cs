using app_demo3.Model;
using Dapper;
using MySql.Data.MySqlClient;
namespace app_demo3.Data
{
    public class CRUDEmpleado : IEmpleado
    {
        private Configuracion _conexion;

        //inyectar al constructor la conexion de la clase Configuracion
        public CRUDEmpleado(Configuracion conexion)
        {
            _conexion = conexion;
        }

        //Metodo para conectar
        protected MySqlConnection Conectar()
        {
            return new MySqlConnection(_conexion.Conectar);
        }

        //Metodo para listar productos
        public async Task<IEnumerable<Empleado>> ListarEmpleado()
        {
            var bd = Conectar();

            String cad_sql = @"select * from tb_empleado";

            return await bd.QueryAsync<Empleado>(cad_sql, new { });
        }

        //Metodo para mostrar la informacion de un proyecto
        public async Task<Empleado> MostrarEmpleado(String id)
        {
            var bd = Conectar();

            String cad_sql = @"select * from tb_empleado where id = @idEmp";

            return await bd.QueryFirstAsync<Empleado>(cad_sql, new { idEmp = id });
        }

        //Metodo para registrar un producto
        public async Task<bool> RegistrarEmpleado(Empleado empleado)
        {
            var bd = Conectar();

            String cad_sql = @"insert into tb_empleado values 
                                (@idEmp, @nom, @apel, @car, @fech_contrato)";

            int n = await bd.ExecuteAsync(cad_sql, new
            {
                idEmp = empleado.id,
                nom = empleado.nombre,
                apel = empleado.apellido,
                car = empleado.cargo,
                fech_contrato = empleado.fecha_contrato
            });

            return n > 0;
        }

        //Metodo para actualizar un producto
        public async Task<bool> ActualizarEmpleado(Empleado empleado)
        {
            var bd = Conectar();

            String cad_sql = @"update tb_empleado set
                                nombre = @nom, apellido = @apel, cargo = @car, fecha_contrato = @fech_contrato, where id = @idEmp";

            int n = await bd.ExecuteAsync(cad_sql, new
            {
                idEmp = empleado.id,
                nom = empleado.nombre,
                apel = empleado.apellido,
                car = empleado.cargo,
                fech_contrato = empleado.fecha_contrato
            });

            return n > 0;
        }

        public async Task<bool> EliminarEmpleado(String codigo)
        {
            var bd = Conectar();

            String cad_sql = @"delete from tb_empleado where id = @idEmp";

            int n = await bd.ExecuteAsync(cad_sql, new { idEmp = codigo });

            return n > 0;
        }
    }
}
