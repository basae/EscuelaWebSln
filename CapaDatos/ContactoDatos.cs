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
    public class ContactoDatos : IContactoDatos
    {
        private readonly IConexionBase conexionBase;

        public ContactoDatos(IConexionBase conexionBase)
        {
            this.conexionBase = conexionBase;
        }
        public RespuestaServicio<int> Crear(Contacto contacto)
        {                        
            RespuestaServicio<int> respuesta = new();
            try
            {
                Dictionary<string, object> parametros = new();
                parametros.Add("@Email", contacto.Email);
                parametros.Add("@Telefono", contacto.Telefono);
                var dt = conexionBase.ExeStoreProcedure("sp_contacto_ins", parametros);
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
        public RespuestaServicio<int> Modificar(int id, Contacto contacto)
        {
            RespuestaServicio<int> respuesta = new();
            try
            {
                Dictionary<string, object> parametros = new();
                parametros.Add("@Id", id);
                parametros.Add("@Email", contacto.Email);
                parametros.Add("@Telefono", contacto.Telefono);
                var dt = conexionBase.ExeStoreProcedure("sp_contacto_ins", parametros);
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
        public RespuestaServicio<Contacto> Obtener(int id)
        {
            RespuestaServicio<Contacto> respuesta = new();
            try
            {
                Dictionary<string, object> parametros = new();
                parametros.Add("@Id", id);
                var dt = conexionBase.ExeStoreProcedure("sp_contacto_sel", parametros);
                if (dt.Rows.Count > 0)
                {
                    respuesta.Result = (from r in dt.Rows.Cast<DataRow>()
                                        select new Contacto
                                        {
                                            Id = r.Field<int?>("Id"),
                                            Email = r.Field<string>("Email"),
                                            Telefono = r.Field<string>("Telefono")
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
    }
}
