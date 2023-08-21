using Modelos;
using Modelos.Generico;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public interface IContactoNegocio
    {
        Task<RespuestaServicio<int>> Crear(Contacto contacto);
        RespuestaServicio<int> Modificar(int id, Contacto contacto);
        RespuestaServicio<Contacto> Obtener(int id);
    }
}