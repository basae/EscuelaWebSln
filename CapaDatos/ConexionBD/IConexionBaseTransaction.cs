using System.Collections.Generic;
using System.Data;

namespace CapaDatos.ConexionBD
{
    public interface IConexionBaseTransaction
    {
        void CommitTransaccion();
        void CrearTransaccion();        
        void RollBack();
    }
}