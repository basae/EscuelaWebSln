using System.Data;

namespace CapaDatos.ConexionBD
{
    public interface IFabricaConexion
    {
        IDbConnection Create();
    }
}