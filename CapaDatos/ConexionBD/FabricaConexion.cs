using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ConexionBD
{
    public class FabricaConexion : IFabricaConexion,IDisposable
    {
        private readonly DbProviderFactory _proveedor;
        private readonly string _cadenaConexion;

        public FabricaConexion(string NombreConexion, IConfiguration configuration)
        {
            if (string.IsNullOrWhiteSpace(NombreConexion)) throw new ArgumentNullException("el nombre de la cadena de conexion no puede ser vacia o nula");
            DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);
            _proveedor = DbProviderFactories.GetFactory("System.Data.SqlClient");
            _cadenaConexion = configuration.GetConnectionString(NombreConexion);
        }
        public IDbConnection Create()
        {
            IDbConnection conn = _proveedor.CreateConnection();
            conn.ConnectionString = _cadenaConexion;
            return conn;
        }
        public void Dispose()
        {
        }
    }
}
