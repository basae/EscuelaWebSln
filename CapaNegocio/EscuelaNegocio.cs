using CapaDatos;
using CapaDatos.ConexionBD;
using Modelos;
using Modelos.Generico;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class EscuelaNegocio : IEscuelaNegocio
    {
        private readonly IEscuelaDatos escuelaDatos;
        private readonly IDireccionNegocio direccionNegocio;
        private readonly IContactoNegocio contactoNegocio;
        private readonly IUsuarioNegocio usuarioNegocio;
        private readonly IConexionBaseTransaction context;

        public EscuelaNegocio(IEscuelaDatos escuelaDatos, IDireccionNegocio direccionNegocio, IContactoNegocio contactoNegocio, IUsuarioNegocio usuarioNegocio, IConexionBaseTransaction context)
        {
            this.escuelaDatos = escuelaDatos;
            this.direccionNegocio = direccionNegocio;
            this.contactoNegocio = contactoNegocio;
            this.usuarioNegocio = usuarioNegocio;
            this.context = context;
        }
        public async Task<RespuestaServicio<Escuela>> Guardar(Escuela escuela)
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

                context.CrearTransaccion();//Hilo 1
                //guardamos contacto
                var RespuestaContacto = await contactoNegocio.Crear(escuela.Contacto);//hilo 2
                if (RespuestaContacto.Error)
                    throw new Exception(RespuestaContacto.Message);
                escuela.Contacto.Id = RespuestaContacto.Result;

                //guardamos direccion
                var GuardaDireccion = await direccionNegocio.Guardar(escuela.Direccion);//hilo 3
                if (GuardaDireccion.Error)
                    throw new Exception(GuardaDireccion.Message);
                escuela.Direccion.Id = GuardaDireccion.Result;

                //guardamos usuario generado
                escuela.Usuario.NombreUsuario = escuela.Clave;
                escuela.Usuario.Rols.Add(new Catalogo { Id = "2" });
                var guardaUsuario = await usuarioNegocio.Crear(escuela.Usuario);//hilo 4
                if (guardaUsuario.Error)
                    throw new Exception(guardaUsuario.Message);
                escuela.Usuario.Id = guardaUsuario.Result;
                //guardamos la escuela
                var GuardarEscuela = await escuelaDatos.Guardar(escuela);//hilo 5
                if (GuardarEscuela.Error)
                    throw new Exception(GuardarEscuela.Message);
                context.CommitTransaccion();//hilo 6

                respuesta = await Obtener(GuardarEscuela.Result.Value); //hilo 7


            }
            catch (Exception ex)
            {
                context.RollBack();
                respuesta.Error = true;
                respuesta.Message = ex.Message;
            }
            return respuesta;
        }
        public async Task<RespuestaServicio<Escuela>> Modificar(Escuela escuela)
        {
            RespuestaServicio<Escuela> respuesta = new();
            try
            {
                if (escuela is null)
                    throw new ArgumentNullException("objeto escuela invalido");
                if (!escuela.Id.HasValue)
                    throw new Exception("id requerido para actualización de registro");

                var GuardarEscuela = escuelaDatos.Modificar(escuela);
                if (GuardarEscuela.Error)
                    throw new Exception(GuardarEscuela.Message);
                respuesta = await Obtener(GuardarEscuela.Result.Value);


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
                respuesta = await escuelaDatos.Obtener(id_escuela);
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
                respuesta = await escuelaDatos.Obtener();
            }
            catch (Exception ex)
            {
                respuesta.Error = true;
                respuesta.Message = ex.Message;
            }
            return respuesta;
        }
        public RespuestaServicio<bool> AsignarEstatusReg(int id_escuela, string Estatus)
        {
            RespuestaServicio<bool> respuesta = new();
            try
            {
                Escuela escuela = new Escuela { Id = id_escuela, EstadoReg = new Catalogo { Id = Estatus } };
                var RespuestaAssignarEstatus = escuelaDatos.Modificar(escuela);
                if (RespuestaAssignarEstatus.Error)
                    throw new Exception(RespuestaAssignarEstatus.Message);
                respuesta.Result = true;
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
