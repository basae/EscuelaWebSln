using Modelos.Generico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Escuela
    {
        public int? Id { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public DateTime? Anioregistro { get; set; }
        public Catalogo NivelEducativo { get; set; } = new Catalogo();
        public string Telefono { get; set; }
        public Direccion Direccion { get; set; } = new Direccion();
        public Catalogo EstadoReg { get; set; } = new Catalogo();

    }
}
