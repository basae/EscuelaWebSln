using CapaDatos;
using CapaDatos.ConexionBD;
using Modelos;
using Modelos.Generico;
using System;

namespace CapaNegocio
{
    public class EscuelaNegocio
    {
        private readonly IEscuelaDatos escuelaDatos;
        private readonly IDireccionDatos direccionNegocio;
        private readonly IConexionBaseTransaction context;

        public EscuelaNegocio(IEscuelaDatos escuelaDatos, IDireccionDatos direccionNegocio, IConexionBaseTransaction context)
        {
            this.escuelaDatos = escuelaDatos;
            this.direccionNegocio = direccionNegocio;
            this.context = context;
        }
        public RespuestaServicio<Escuela> Guardar(Escuela escuela)
        {
            RespuestaServicio<Escuela> respuesta = new();
            try
            {
                if (escuela is null)
                    throw new ArgumentNullException("objeto escuela invalido");
                if (string.IsNullOrWhiteSpace(escuela.Clave))
                    throw new ArgumentNullException("la clave de la escuela no puede estar vacia.");
                if (string.IsNullOrWhiteSpace(escuela.Nombre))
                    throw new ArgumentNullException("el nombre de la escuela debe contener un valor.");
                if (string.IsNullOrWhiteSpace(escuela.NivelEducativo.Id))
                    throw new ArgumentNullException("el nivel del plantel educativo no puede estar vacio.");
                if (!escuela.Anioregistro.HasValue)
                    throw new ArgumentNullException("la fecha de creación del plantel no puede estar vacio.");

                context.CrearTransaccion();
                var GuardaDireccion = direccionNegocio.Guardar(escuela.Direccion);
                if (GuardaDireccion.Error)
                    throw new Exception(GuardaDireccion.Message);
                escuela.Direccion.Id = GuardaDireccion.Result;
                var GuardarEscuela = escuelaDatos.Guardar(escuela);
                if (GuardarEscuela.Error)
                    throw new Exception(GuardarEscuela.Message);
                context.CommitTransaccion();
                respuesta = Obtener(GuardarEscuela.Result.Value);


            }
            catch (Exception ex)
            {
                context.RollBack();
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
                respuesta = escuelaDatos.Obtener(id_escuela);
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
