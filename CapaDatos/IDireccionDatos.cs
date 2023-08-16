using Modelos.Generico;
using System.Collections.Generic;

namespace CapaDatos
{
    public interface IDireccionDatos
    {
        RespuestaServicio<int?> Guardar(Direccion direccion);
        RespuestaServicio<int?> Modificar(Direccion direccion);
        RespuestaServicio<DireccionGenerica> Obtener(int id_direccion);
        RespuestaServicio<IEnumerable<DireccionGenerica>> Obtener(string CodigoPostal);
    }
}