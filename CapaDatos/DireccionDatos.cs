using CapaDatos.ConexionBD;
using Modelos.Generico;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DireccionDatos : IDireccionDatos
    {
        private readonly IConexionBase contextBD;
        public DireccionDatos(IConexionBase contextBD)
        {
            this.contextBD = contextBD;
        }
        public RespuestaServicio<int?> Guardar(Direccion direccion)
        {
            RespuestaServicio<int?> respuesta = new RespuestaServicio<int?>();
            try
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@Id_Colonia", direccion.Colonia.Id);
                parametros.Add("@Calle", direccion.Calle);
                parametros.Add("@NoInt", direccion.NoInt);
                parametros.Add("@NoExt", direccion.NoExt);
                parametros.Add("@Lat", direccion.Lat);
                parametros.Add("@Lng", direccion.Lng);

                DataTable dt = contextBD.ExeStoreProcedure("sp_direccion_ins", parametros);
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
        public RespuestaServicio<int?> Modificar(Direccion direccion)
        {
            RespuestaServicio<int?> respuesta = new RespuestaServicio<int?>();
            try
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@Id_Colonia", direccion.Colonia.Id);
                parametros.Add("@Calle", direccion.Calle);
                parametros.Add("@NoInt", direccion.NoInt);
                parametros.Add("@NoExt", direccion.NoExt);
                parametros.Add("@Lat", direccion.Lat);
                parametros.Add("@Lng", direccion.Lng);

                DataTable dt = contextBD.ExeStoreProcedure("sp_direccion_upd", parametros);
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
        public RespuestaServicio<IEnumerable<DireccionGenerica>> Obtener(string CodigoPostal)
        {
            RespuestaServicio<IEnumerable<DireccionGenerica>> respuesta = new();
            try
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@CodigoPostal", CodigoPostal);
                DataTable dt = contextBD.ExeStoreProcedure("sp_direccion_sel_cp", parametros);
                if (dt.Rows.Count > 0)
                {
                    respuesta.Result = (from r in dt.Rows.Cast<DataRow>()
                                        select new DireccionGenerica
                                        {
                                            CodigoPostal = r.Field<string>("CodigoPostal"),
                                            Colonia = new Catalogo { Id = r.Field<string>("Id"), Descripcion = r.Field<string>("Descripcion") },
                                            Municipio = new Catalogo { Id = r.Field<string>("id_municipio"), Descripcion = r.Field<string>("desc_municipio") },
                                            Estado = new Catalogo { Id = r.Field<string>("id_estado"), Descripcion = r.Field<string>("desc_estado") }
                                        }).ToList();
                }

            }
            catch (Exception ex)
            {
                respuesta.Error = true;
                respuesta.Message = ex.Message;
            }
            return respuesta;
        }
        public RespuestaServicio<DireccionGenerica> Obtener(int id_direccion)
        {
            RespuestaServicio<DireccionGenerica> respuesta = new();
            try
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@id_direccion", id_direccion);
                DataTable dt = contextBD.ExeStoreProcedure("sp_direccion_sel_by_id", parametros);
                if (dt.Rows.Count > 0)
                {
                    respuesta.Result = new Direccion(dt);
                }

            }
            catch (Exception ex)
            {
                respuesta.Error = true;
                respuesta.Message = ex.Message;
            }
            return respuesta;
        }
    }
}
