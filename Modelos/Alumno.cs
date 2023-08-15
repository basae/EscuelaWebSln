using Modelos.Generico;
using Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Alumno :Persona
    {        
        public string NoControl { get; set; }
        public Catalogo Grado { get; set; }
        public Catalogo Grupo { get; set; }
        public Catalogo Turno { get; set; }        
        public Alumno()
        {
            Grado = new();
            Grupo = new();
            Turno = new();
        }        
    }
}
