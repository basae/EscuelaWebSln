using Modelos;
using Modelos.Generico;

namespace CapaDatos
{
    public interface IUsuarioDatos
    {
        RespuestaServicio<int> Crear(Usuario usuario);
        RespuestaServicio<int> Modificar(Usuario usuario);
        RespuestaServicio<Usuario> Obtener(int id_usaurio);
    }
}