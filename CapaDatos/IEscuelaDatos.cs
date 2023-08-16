using Modelos;
using Modelos.Generico;

namespace CapaDatos
{
    public interface IEscuelaDatos
    {
        RespuestaServicio<int?> Guardar(Escuela escuela);
        RespuestaServicio<int?> Modificar(Escuela escuela);
        RespuestaServicio<Escuela> Obtener(int id_escuela);
    }
}