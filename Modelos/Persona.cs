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
        public string Amaterno { get; set; }
        public string Apaterno { get; set; }
        public Direccion Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Catalogo Genero { get; set; }
        public int? Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
    }

    public class Persona : IPersona
    {
        public int? Id { get; set; }
        public string Nombre { get; set; }
        public string Apaterno { get; set; }
        public string Amaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Catalogo Genero { get; set; } = new Catalogo();
        public string Telefono { get; set; }
        public Direccion Direccion { get; set; } = new Direccion();

    }
}
