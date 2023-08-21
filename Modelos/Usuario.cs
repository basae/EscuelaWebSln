using Modelos.Generico;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Usuario : DatosControl
    {
        public int? Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public List<Catalogo> Rols { get; set; } = new();
        public Catalogo EstadoReg { get; set; } = new Catalogo();
    }    


}
