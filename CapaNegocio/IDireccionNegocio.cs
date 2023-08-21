using Modelos.Generico;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public interface IDireccionNegocio
    {
        Task<RespuestaServicio<int?>> Guardar(Direccion direccion);
        RespuestaServicio<IEnumerable<DireccionGenerica>> Obtener(string CodigoPostal);
    }

}