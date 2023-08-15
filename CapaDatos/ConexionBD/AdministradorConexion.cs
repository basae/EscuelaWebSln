using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CapaDatos.ConexionBD
{
    public class AdministradorConexion : IAdministradorConexion, IDisposable
    {
        private readonly IDbConnection conexion;
        private readonly ReaderWriterLockSlim Bloqueo;
        public readonly LinkedList<IAdministradorTransacciones> transacciones;
        public AdministradorConexion(IFabricaConexion _fabrica)
        {
            conexion = _fabrica.Create();
            Bloqueo = new ReaderWriterLockSlim();
            transacciones = new LinkedList<IAdministradorTransacciones>();
            conexion.Open();
        }
        public IDbCommand CreateCommand(string nombreProcedimiento)
        {
            var cmd = conexion.CreateCommand();
            cmd.CommandText = nombreProcedimiento;
            cmd.CommandTimeout = 0;
            Bloqueo.EnterReadLock();
            if (transacciones.Count > 0)
                cmd.Transaction = transacciones.First.Value.ObtenerTransaccion();
            Bloqueo.ExitReadLock();
            return cmd;
        }
        public void AddParameter(IDbCommand cmd, string Name, object v)
        {
            IDataParameter param = cmd.CreateParameter();
            param.ParameterName = Name;
            param.Value = v;
            cmd.Parameters.Add(param);
        }
        public IAdministradorTransacciones CrearTransaccion()
        {
            var transaccion = conexion.BeginTransaction();
            IAdministradorTransacciones t = new AdministradorTransacciones(transaccion, RemoverTransaccion, RemoverTransaccion);
            Bloqueo.EnterWriteLock();
            transacciones.AddLast(t);
            Bloqueo.ExitWriteLock();
            return t;
        }
        public void Commit()
        {
            if (transacciones.Count > 0)
                transacciones.First().Commit();
        }
        public void Rollback()
        {
            if (transacciones.Count > 0)
                transacciones.First().Rollback();
        }
        private void RemoverTransaccion(IAdministradorTransacciones obj)
        {
            Bloqueo.EnterWriteLock();
            transacciones.Remove(obj);
            Bloqueo.ExitWriteLock();
        }        
        public void Dispose()
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                var error = ex;
            }
        }
        ~AdministradorConexion()
        {
            Dispose();
        }
    }
}
