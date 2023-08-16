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
    public class EscuelaDatos : IEscuelaDatos
    {
        private IConexionBase conexionBD;
        public EscuelaDatos(IConexionBase conexion)
        {
            conexionBD = conexion;
        }
        public RespuestaServicio<int?> Guardar(Escuela escuela)
        {
            RespuestaServicio<int?> respuesta = new RespuestaServicio<int?>();
            try
            {
                Dictionary<string, object> parameter = new Dictionary<string, object>();
                parameter.Add("@Clave", escuela.Clave);
                parameter.Add("@Nombre", escuela.Nombre);
                parameter.Add("@Id_Direccion", escuela.Direccion.Id);
                parameter.Add("@AnioRegistro", escuela.Anioregistro);
                parameter.Add("@Id_Nivel_Educativo", escuela.NivelEducativo.Id);
                parameter.Add("@Telefono", escuela.Telefono);
                DataTable dt = conexionBD.ExeStoreProcedure("sp_escuela_ins", parameter);
                if (dt.Rows.Count > 0)
                {
                    respuesta.Result = dt.Rows[0].Field<int>(0);
                }
                else
                    throw new Exception("algo ocurrio en la inserción, revisalo con el área de sistemas.");
            }
            catch (Exception ex)
            {
                respuesta.Error = true;
                respuesta.Message = ex.Message;
            }
            return respuesta;
        }
        public RespuestaServicio<int?> Modificar(Escuela escuela)
        {
            RespuestaServicio<int?> respuesta = new RespuestaServicio<int?>();
            try
            {
                Dictionary<string, object> parameter = new Dictionary<string, object>();
                parameter.Add("@Id", escuela.Id);
                parameter.Add("@Clave", escuela.Clave);
                parameter.Add("@Nombre", escuela.Nombre);
                parameter.Add("@Id_Direccion", escuela.Direccion.Id);
                parameter.Add("@AnioRegistro", escuela.Anioregistro);
                parameter.Add("@Id_Nivel_Educativo", escuela.NivelEducativo.Id);
                parameter.Add("@Telefono", escuela.Telefono);
                parameter.Add("@Cve_Estatus", escuela.EstadoReg.Id);

                DataTable dt = conexionBD.ExeStoreProcedure("sp_escuela_upd", parameter);
                if (dt.Rows.Count > 0)
                {
                    respuesta.Result = dt.Rows[0].Field<int>(0);
                }
                else
                    throw new Exception("algo ocurrio en la actualización, revisalo con el área de sistemas.");
            }
            catch (Exception ex)
            {
                respuesta.Error = true;
                respuesta.Message = ex.Message;
            }
            return respuesta;
        }
        public RespuestaServicio<Escuela> Obtener(int id_escuela)
        {
            RespuestaServicio<Escuela> respuesta = new();
            try
            {
                Dictionary<string, object> parameter = new Dictionary<string, object>();
                parameter.Add("@id_escuela", id_escuela);

                DataSet ds = conexionBD.ExeStoreProcedureDataSet("sp_escuela_sel_by_id", parameter);
                if (ds.Tables.Count > 0)
                {
                    respuesta.Result = (from dt in ds.Tables[0].Rows.Cast<DataRow>()
                                        select new Escuela
                                        {
                                            Id = dt.Field<int?>("Id"),
                                            Clave = dt.Field<string>("Clave"),
                                            Nombre = dt.Field<string>("Nombre"),
                                            Direccion = new Direccion(ds.Tables[1]),
                                            Anioregistro = dt.Field<DateTime?>("AnioRegistro"),
                                            NivelEducativo = new Catalogo(dt.Field<string>("Id_Nivel_Educativo"), dt.Field<string>("NivelEducativo_Desc")),
                                            Telefono = dt.Field<string>("Telefono"),
                                            EstadoReg = new Catalogo(dt.Field<string>("Cve_EstadoReg"), dt.Field<string>("EstadoReg_Desc"))
                                        }).Single();
                }
                else
                    throw new Exception("algo ocurrio en la consulta, revisalo con el área de sistemas.");
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
