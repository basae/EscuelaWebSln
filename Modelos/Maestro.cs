using Modelos.Generico;
using Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Maestro : Persona, IDatosControl
    {
        public string CedulaProfesional { get; set; }
        public Catalogo EstadoReg { get; set; } = new Catalogo();
        public DateTime? FechaModificacion { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
