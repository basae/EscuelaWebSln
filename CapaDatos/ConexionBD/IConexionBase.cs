using System.Collections.Generic;
using System.Data;

namespace CapaDatos.ConexionBD
{
    public interface IConexionBase
    {
        DataTable ExeStoreProcedure(string Name, Dictionary<string, object> Parameters);
        DataSet ExeStoreProcedureDataSet(string Name, Dictionary<string, object> Parameters);
        void CrearTransaccion();
        void CommitTransaccion();
        void RollBack();
    }
}