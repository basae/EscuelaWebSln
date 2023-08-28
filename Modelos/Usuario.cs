using Microsoft.AspNetCore.Http;
using Modelos.Generico;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public interface IUsuario
    {
        [DisplayName(displayName: "Contraseña")]
        string Contrasena { get; set; }
        [DisplayName(displayName: "Usuario")]
        string NombreUsuario { get; set; }
    }

    public class Usuario : DatosControl, IUsuario
    {
        public int? Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public List<Catalogo> Rols { get; set; } = new();
        public Catalogo EstadoReg { get; set; } = new Catalogo();
    }
    public class UsuarioLogInOut : Usuario, IContacto
    {
        public string Email { get; set; }
        public string Telefono { get; set; }
        public bool Autenticado { get; private set; } = false;
        public TypeAuth TipoAut { get; set; }
        public string Id_Entidad { get; set; }
        public UsuarioLogInOut(ClaimsPrincipal _principal)
        {
            if (_principal.Identity.IsAuthenticated)
            {
                Rols = _principal.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => new Catalogo { Id = x.Value, Descripcion = x.Issuer }).ToList();
                Telefono = _principal.FindFirst(x => x.Type == ClaimTypes.MobilePhone).Value;
                Email = _principal.FindFirst(x => x.Type == ClaimTypes.Email).Value;
                NombreUsuario = _principal.FindFirst(x => x.Type == ClaimTypes.Name).Value;
                Autenticado = true;
                Id = Convert.ToInt32(_principal.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value);
                TipoAut = Enum.Parse<TypeAuth>(_principal.FindFirst(x => x.Type == ClaimTypes.Authentication).Value);
                Id_Entidad = _principal.FindFirst(ClaimTypes.GroupSid).Value;
            }
        }

        public UsuarioLogInOut()
        {
        }
    }
    public enum TypeAuth
    {
        ESCUELA = 1,
        ALUMNO,
        MAESTRO,
        ADMIN
    }
    public static class IUsuarioExtension
    {
        public static void Validar(this IUsuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException("usuario y contrseña requeridos");
            if (string.IsNullOrWhiteSpace(usuario.NombreUsuario))
                throw new ArgumentNullException("nombre de usuario requerido");
            if (string.IsNullOrWhiteSpace(usuario.Contrasena))
                throw new ArgumentNullException("contraseña requerida");
        }
        public static ClaimsPrincipal ObtenerClaims(this UsuarioLogInOut usuario)
        {
            ClaimsPrincipal principal = new();
            ClaimsIdentity identity = new ClaimsIdentity("EscuelaWebLogin");
            List<Claim> respuesta = new List<Claim>();

            respuesta.Add(new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()));
            respuesta.Add(new Claim(ClaimTypes.Name, usuario.NombreUsuario));
            respuesta.Add(new Claim(ClaimTypes.Email, usuario.Email ?? ""));
            respuesta.Add(new Claim(ClaimTypes.MobilePhone, usuario.Telefono ?? ""));
            respuesta.Add(new Claim(ClaimTypes.Authentication, usuario.TipoAut.ToString()));
            respuesta.Add(new Claim(ClaimTypes.GroupSid, usuario.Id_Entidad ?? ""));

            usuario.Rols.ForEach(x => respuesta.Add(new Claim(ClaimTypes.Role, x.Id, ClaimValueTypes.String, x.Descripcion)));
            identity.AddClaims(respuesta);
            principal.AddIdentity(identity);


            return principal;
        }
    }

}
