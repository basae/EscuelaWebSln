using Modelos.Generico;
using Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public interface IPersona
    {
        string Amaterno { get; set; }
        string Apaterno { get; set; }
        Direccion Direccion { get; set; }
        DateTime FechaNacimiento { get; set; }
        Catalogo Genero { get; set; }
        string Nombre { get; set; }
        string Telefono { get; set; }
        string CorreoElectronico { get; set; }
    }

    public class Persona : IPersona
    {
        public string Nombre { get; set; }
        public string Apaterno { get; set; }
        public string Amaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CorreoElectronico { get; set; }
        public Catalogo Genero { get; set; } = new Catalogo();
        public string Telefono { get; set; }
        public Direccion Direccion { get; set; } = new Direccion();
        public Usuario Usuario { get; set; } = new Usuario();        
    }
}
