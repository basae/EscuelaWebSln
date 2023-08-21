using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public interface IContacto
    {
        public int? Id { get; set; }
        string Email { get; set; }
        string Telefono { get; set; }
    }

    public class Contacto : IContacto
    {
        public int? Id { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
    }
    public static class IContactoExtensions
    {
        public static void ValidaContacto(this IContacto contacto)
        {
            if (contacto == null)
                throw new ArgumentNullException("se requiere email y teléfono.");
            if (string.IsNullOrWhiteSpace(contacto.Email))
                throw new ArgumentNullException("se requiere email.");
            if (string.IsNullOrWhiteSpace(contacto.Telefono))
                throw new Exception("se requiere teléfono");

        }
    }
}
