using System.Data;

namespace CapaDatos.ConexionBD
{
    public interface IAdministradorConexion
    {
        IAdministradorTransacciones CrearTransaccion();
        IDbCommand CreateCommand(string nombreProcedimiento);
        void AddParameter(IDbCommand cmd, string Name, object v);
        void Commit();
        void Rollback();
        void Dispose();
    }
}