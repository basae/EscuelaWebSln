using Modelos;
using Modelos.Generico;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public interface IUsuarioNegocio
    {
        Task<RespuestaServicio<int>> Crear(Usuario usuario);
    }
}