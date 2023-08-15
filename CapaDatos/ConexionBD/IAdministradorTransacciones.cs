using System.Data;

namespace CapaDatos.ConexionBD
{
    public interface IAdministradorTransacciones
    {
        void Commit();
        void Rollback();
        IDbTransaction ObtenerTransaccion();
    }
}