using Microsoft.Extensions.Configuration;
using Modelos.Estaticos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ConexionBD
{
    public class ConexionBase : IConexionBase, IDisposable, IConexionBaseTransaction
    {
        //private SqlConnection _conexion;
        private readonly IAdministradorConexion Conexion;
        public ConexionBase(IAdministradorConexion contextoConexion)
        {
            //_conexion = new SqlConnection(ConfiguracionApp.Configuracion.GetConnectionString("EscuelaWebConexion"));
            Conexion = contextoConexion;
        }
        public void Dispose()
        {
            Conexion.Dispose();
        }
        public void CrearTransaccion()
        {
            Conexion.CrearTransaccion();
        }
        public void CommitTransaccion()
        {
            Conexion.Commit();
        }
        public void RollBack()
        {
            Conexion.Rollback();
        }
        public DataTable ExeStoreProcedure(string Name, Dictionary<string, object> Parameters)
        {
            DataTable dt = new DataTable();
            try
            {

                using (var cmd = Conexion.CreateCommand(Name))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    if (Parameters != null)
                        foreach (var parameter in Parameters)
                        {
                            Conexion.AddParameter(cmd, parameter.Key, parameter.Value);
                        }
                    using (var dr = cmd.ExecuteReader())
                    {
                        dt.Load(dr);
                    }
                }
                return dt;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
        public DataTable ExeStoreProcedure(string Name)
        {
            DataTable dt = new DataTable();
            try
            {

                using (var cmd = Conexion.CreateCommand(Name))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;                    
                    using (var dr = cmd.ExecuteReader())
                    {
                        dt.Load(dr);
                    }
                }
                return dt;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
        public DataSet ExeStoreProcedureDataSet(string Name, Dictionary<string, object> Parameters)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var cmd = Conexion.CreateCommand(Name))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    if (Parameters != null)
                        foreach (var parameter in Parameters)
                        {
                            Conexion.AddParameter(cmd, parameter.Key, parameter.Value);

                        }
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (!dr.IsClosed)
                        {
                            DataTable dt = new DataTable();
                            dt.Load(dr);
                            ds.Tables.Add(dt);
                        }
                    }
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }        
    }
}
