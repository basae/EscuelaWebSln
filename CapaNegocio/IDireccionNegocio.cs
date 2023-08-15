using Modelos.Generico;

namespace CapaNegocio
{
    public interface IDireccionNegocio
    {
        RespuestaServicio<int?> Guardar(Direccion direccion);
    }
}