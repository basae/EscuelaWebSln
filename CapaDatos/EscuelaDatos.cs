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
        public async Task<RespuestaServicio<int?>> Guardar(Escuela escuela)
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
                parameter.Add("@Id_Contacto", escuela.Contacto.Id);
                parameter.Add("@Id_Usuario", escuela.Usuario.Id);

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
        public async Task<RespuestaServicio<Escuela>> Obtener(int id_escuela)
        {
            RespuestaServicio<Escuela> respuesta = new();
            try
            {
                Dictionary<string, object> parameter = new Dictionary<string, object>();
                parameter.Add("@id_escuela", id_escuela);

                DataTable dt = conexionBD.ExeStoreProcedure("sp_escuela_sel_by_id", parameter);
                if (dt.Rows.Count > 0)
                {
                    respuesta.Result = (from r in dt.Rows.Cast<DataRow>()
                                        select new Escuela
                                        {
                                            Id = r.Field<int?>("Id"),
                                            Clave = r.Field<string>("Clave"),
                                            Nombre = r.Field<string>("Nombre"),
                                            Direccion = new Direccion { Id = r.Field<int?>("Id_Direccion") },
                                            Anioregistro = r.Field<DateTime?>("AnioRegistro"),
                                            NivelEducativo = new Catalogo(r.Field<string>("Id_Nivel_Educativo"), r.Field<string>("NivelEducativo_Desc")),
                                            EstadoReg = new Catalogo(r.Field<string>("Cve_EstadoReg"), r.Field<string>("EstadoReg_Desc")),
                                            FechaRegistro = r.Field<DateTime>("FechaRegistro"),
                                            FechaModificacion = r.Field<DateTime?>("FechaModificacion"),
                                            Usuario = new Usuario { Id = r.Field<int?>("Id_usuario") },
                                            Contacto = new Contacto { Id = r.Field<int?>("Id_Contacto") }
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
        public async Task<RespuestaServicio<IEnumerable<Escuela>>> Obtener()
        {
            RespuestaServicio<IEnumerable<Escuela>> respuesta = new();
            try
            {
                DataTable dt = conexionBD.ExeStoreProcedure("sp_escuela_sel");
                if (dt.Rows.Count > 0)
                {
                    respuesta.Result = from r in dt.Rows.Cast<DataRow>()
                                       select new Escuela
                                       {
                                           Id = r.Field<int?>("Id"),
                                           Clave = r.Field<string>("Clave"),
                                           Nombre = r.Field<string>("Nombre"),
                                           Anioregistro = r.Field<DateTime?>("AnioRegistro"),
                                           NivelEducativo = new Catalogo(r.Field<string>("Id_Nivel_Educativo"), r.Field<string>("NivelEducativo_Desc")),
                                           EstadoReg = new Catalogo(r.Field<string>("Cve_EstadoReg"), r.Field<string>("EstadoReg_Desc")),
                                           FechaRegistro = r.Field<DateTime>("FechaRegistro"),
                                           FechaModificacion = r.Field<DateTime?>("FechaModificacion"),
                                           Usuario = new Usuario { Id = r.Field<int?>("Id_usuario") },
                                           Contacto = new Contacto { Id = r.Field<int?>("Id_Contacto") },
                                           Direccion = new Direccion { Id = r.Field<int?>("Id_Direccion") },
                                       };
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
