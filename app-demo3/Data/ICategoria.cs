using app_demo3.Model;

namespace app_demo3.Data
{
    public interface ICategoria
    {
        Task<IEnumerable<Categoria>> ListarCategoria();
        Task<Categoria> MostrarCategoria(String id);
        Task<bool> RegistrarCategoria(Categoria categoria);
        Task<bool> ActualizarCategoria(Categoria categoria);
        Task<bool> EliminarCategoria(String id);
    }
}
