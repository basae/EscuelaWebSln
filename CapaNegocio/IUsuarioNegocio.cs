using Modelos;
using Modelos.Generico;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public interface IUsuarioNegocio
    {
        Task<RespuestaServicio<int>> Crear(Usuario usuario);
        Task<RespuestaServicio<ClaimsPrincipal>> Login(IUsuario usuario);
    }
}