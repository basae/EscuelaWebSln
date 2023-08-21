using Modelos;
using Modelos.Generico;

namespace CapaDatos
{
    public interface IContactoDatos
    {
        RespuestaServicio<int> Crear(Contacto contacto);
        RespuestaServicio<int> Modificar(int id, Contacto contacto);
        RespuestaServicio<Contacto> Obtener(int id);
    }
}