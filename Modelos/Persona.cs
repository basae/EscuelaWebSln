using Modelos.Generico;
using Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public interface IPersona
    {
        string Amaterno { get; set; }
        string Apaterno { get; set; }
        IDireccion Direccion { get; set; }
        DateTime? FechaNacimiento { get; set; }
        Catalogo Genero { get; set; }
        string Nombre { get; set; }
        Contacto Contacto { get; set; }
    }

    public class Persona : Contacto, IPersona
    {
        [StringLength(50, ErrorMessage = "debe contener 8 números", MinimumLength =5)]
        public string Nombre { get; set; }        
        public string Apaterno { get; set; }
        public string Amaterno { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public Catalogo Genero { get; set; } = new Catalogo();
        public IDireccion Direccion { get; set; } = new Direccion();
        public Usuario Usuario { get; set; } = new Usuario();
        public Contacto Contacto { get; set; } = new Contacto();
    }
    public static class IPersonaExtension
    {
        public static void ValidarNuevo(this IPersona persona)
        {
            if (persona == null)
                throw new ArgumentNullException("es necesario llenar los datos requeridos.");
            if (string.IsNullOrWhiteSpace(persona.Nombre))
                throw new ArgumentNullException("nombre requerido");
            if (string.IsNullOrWhiteSpace(persona.Apaterno))
                throw new ArgumentNullException("apellido paterno requerido");
            if (!persona.FechaNacimiento.HasValue)
                throw new ArgumentNullException("fecha de nacimiento requerida");
            if (string.IsNullOrWhiteSpace(persona.Genero.Id))
                throw new ArgumentNullException("genero requerido");
            persona.Contacto.ValidaContacto();
            persona.Direccion.ValidarDatos();
        }
    }
}
