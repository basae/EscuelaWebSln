using Modelos;
using Modelos.Generico;
using System.Threading.Tasks;

namespace CapaDatos
{
    public interface IUsuarioDatos
    {
        Task<RespuestaServicio<int>> Crear(Usuario usuario);
        Task<RespuestaServicio<int>> Modificar(Usuario usuario);
        Task<RespuestaServicio<Usuario>> Obtener(int id_usaurio);
        Task<RespuestaServicio<UsuarioLogInOut>> Login(IUsuario usuario);
    }
}