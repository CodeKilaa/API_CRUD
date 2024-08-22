using app_demo3.Model;

namespace app_demo3.Data
{
    public interface IProducto
    {
        Task<IEnumerable<Producto>> ListarProducto();
        Task<Producto> MostrarProducto(String id);
        Task<bool> RegistrarProducto(Producto producto);
        Task<bool> ActualizarProducto(Producto producto);
        Task<bool> EliminarProducto(String id);
    }
}
