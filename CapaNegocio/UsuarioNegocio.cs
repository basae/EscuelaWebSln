using CapaDatos;
using Modelos;
using Modelos.Generico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class UsuarioNegocio : IUsuarioNegocio
    {
        private readonly IUsuarioDatos usuarioDatos;

        public UsuarioNegocio(IUsuarioDatos usuarioDatos)
        {
            this.usuarioDatos = usuarioDatos;
        }

        public async Task<RespuestaServicio<int>> Crear(Usuario usuario)
        {
            RespuestaServicio<int> respuesta = new();
            try
            {
                if (usuario == null)
                    throw new Exception("objeto invalido.");
                if (string.IsNullOrWhiteSpace(usuario.NombreUsuario))
                    throw new Exception("nombre de usuario debe contener algún valor");
                if (usuario.NombreUsuario.Length < 8)
                    throw new Exception("el nombre de usuario debe contener minimo 8 caracteres");
                if (string.IsNullOrWhiteSpace(usuario.Contrasena))
                    throw new Exception("contraseña requerida");
                if (usuario.Contrasena.Length < 6)
                    throw new Exception("la contraseña debe contener al menos 6 caracteres");
                if (usuario.Rols.Count == 0)
                    throw new Exception("debe contener al menos un rol para asignación");
                respuesta = usuarioDatos.Crear(usuario);
            }
            catch (Exception ex)
            {
                respuesta.Error = true;
                respuesta.Message = ex.Message;
            }
            return respuesta;
        }
        public RespuestaServicio<bool> Modificar(Usuario usuario)
        {
            RespuestaServicio<bool> respuesta = new();
            try
            {
                if (usuario == null)
                    throw new ArgumentNullException("el objeto esta vacio.");
                if (!usuario.Id.HasValue)
                    throw new ArgumentNullException("id requerido para actualización");
                var Respuesta = usuarioDatos.Modificar(usuario);
            }
            catch (Exception ex)
            {
                respuesta.Error = true;
                respuesta.Message = ex.Message;
            }
            return respuesta;
        }
        public RespuestaServicio<Usuario> Obtener(int id_usuario)
        {
            RespuestaServicio<Usuario> respuesta = new();
            try
            {
                if (id_usuario < 1)
                    throw new Exception("id invalido");
                respuesta = usuarioDatos.Obtener(id_usuario);
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
