using Modelos;
using Modelos.Generico;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapaDatos
{
    public interface IEscuelaDatos
    {
        Task<RespuestaServicio<int?>> Guardar(Escuela escuela);
        RespuestaServicio<int?> Modificar(Escuela escuela);
        Task<RespuestaServicio<Escuela>> Obtener(int id_escuela);
        Task<RespuestaServicio<IEnumerable<Escuela>>> Obtener();
    }
}