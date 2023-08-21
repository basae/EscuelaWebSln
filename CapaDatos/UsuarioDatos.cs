using CapaDatos.ConexionBD;
using Modelos;
using Modelos.Generico;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class UsuarioDatos : IUsuarioDatos
    {
        private readonly IConexionBase conexionBase;

        public UsuarioDatos(IConexionBase conexionBase)
        {
            this.conexionBase = conexionBase;
        }
        public RespuestaServicio<int> Crear(Usuario usuario)
        {
            RespuestaServicio<int> respuesta = new();
            try
            {
                Dictionary<string, object> parametros = new();
                parametros.Add("@NombreUsuario", usuario.NombreUsuario);
                parametros.Add("@Contrasena", usuario.Contrasena);
                parametros.Add("@ListaRol", conexionBase.ParseListToTable(usuario.Rols.Select(x => new { x.Id }).ToList(), new Dictionary<string, string>() { { "Id", "id_rol" } }));                

                var dt = conexionBase.ExeStoreProcedure("sp_usuario_ins", parametros);
                if (dt.Rows.Count > 0)
                {
                    respuesta.Result = dt.Rows[0].Field<int>(0);
                }
            }
            catch (Exception ex)
            {
                respuesta.Error = true;
                respuesta.Message = ex.Message;
            }
            return respuesta;
        }
        public RespuestaServicio<int> Modificar(Usuario usuario)
        {
            RespuestaServicio<int> respuesta = new();
            try
            {
                Dictionary<string, object> parametros = new();
                parametros.Add("@ID", usuario.Id);
                parametros.Add("@Contrasena", usuario.Contrasena);
                parametros.Add("@ListaRol", conexionBase.ParseListToTable(usuario.Rols.Select(x => new { x.Id }).ToList(), new Dictionary<string, string>() { { "Id", "id_rol" } }));
                var dt = conexionBase.ExeStoreProcedure("sp_usuario_upd", parametros);
                if (dt.Rows.Count > 0)
                {
                    respuesta.Result = dt.Rows[0].Field<int>(0);
                }
            }
            catch (Exception ex)
            {
                respuesta.Error = true;
                respuesta.Message = ex.Message;
            }
            return respuesta;
        }
        public RespuestaServicio<Usuario> Obtener(int id_usaurio)
        {
            RespuestaServicio<Usuario> respuesta = new();
            try
            {
                Dictionary<string, object> parametros = new();
                parametros.Add("@Id", id_usaurio);
                var ds = conexionBase.ExeStoreProcedureDataSet("sp_usuario_sel_by_id", parametros);
                if (ds.Tables.Count == 2)
                {
                    respuesta.Result = (from r in ds.Tables[0].Rows.Cast<DataRow>()
                                        select new Usuario
                                        {
                                            Id = r.Field<int?>("Id"),
                                            NombreUsuario = r.Field<string>("NombreUsuario"),
                                            EstadoReg = new Catalogo { Id = r.Field<string>("Cve_EstadoReg"), Descripcion = r.Field<string>("Desc_EstadoReg") },
                                            FechaRegistro = r.Field<DateTime>("FechaRegistro"),
                                            FechaModificacion = r.Field<DateTime?>("FechaModificacion"),
                                            Rols = (from r2 in ds.Tables[1].Rows.Cast<DataRow>()
                                                    select new Catalogo
                                                    {
                                                        Id = r2.Field<string>("Id_Rol"),
                                                        Descripcion = r2.Field<string>("Descripcion")
                                                    }).ToList()
                                        }).First();
                }
            }
            catch (Exception ex)
            {
                respuesta.Error = true;
                respuesta.Message = ex.Message;
            }
            return respuesta;
        }
        public DataTable ConvertirListaRol(List<Catalogo> roles)
        {
            DataTable dt = new();
            dt.Columns.Add("id_rol", typeof(int));

            foreach (var item in roles)
            {
                dt.Rows.Add(Convert.ToInt32(item.Id));
            }
            return dt;
        }
    }
}
