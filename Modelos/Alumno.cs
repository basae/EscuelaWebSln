using Modelos.Generico;
using Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Alumno : Persona,IDatosControl
    {
        [DisplayName(displayName:"No. de control")]             
        public int? NoControl { get; set; }
        public Catalogo Grado { get; set; }
        public Catalogo Grupo { get; set; }
        public Catalogo Turno { get; set; }
        public Catalogo EstadoReg { get; set; } = new Catalogo();
        public DateTime? FechaModificacion { get; set; }
        public DateTime FechaRegistro { get; set; }

        public Alumno()
        {
            Grado = new();
            Grupo = new();
            Turno = new();
        }

    }
}
