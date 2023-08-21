using Modelos;
using Modelos.Generico;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public interface IEscuelaNegocio
    {
        RespuestaServicio<bool> AsignarEstatusReg(int id_escuela, string Estatus);
        Task<RespuestaServicio<Escuela>> Guardar(Escuela escuela);
        Task<RespuestaServicio<Escuela>> Modificar(Escuela escuela);
        Task<RespuestaServicio<IEnumerable<Escuela>>> Obtener();
        Task<RespuestaServicio<Escuela>> Obtener(int id_escuela);
    }
}