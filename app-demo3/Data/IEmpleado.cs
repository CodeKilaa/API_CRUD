using app_demo3.Model;

namespace app_demo3.Data
{
    public interface IEmpleado
    {
        Task<IEnumerable<Empleado>> ListarEmpleado();
        Task<Empleado> MostrarEmpleado(String id);
        Task<bool> RegistrarEmpleado(Empleado empleado);
        Task<bool> ActualizarEmpleado(Empleado empleado);
        Task<bool> EliminarEmpleado(String id);
    }
}
