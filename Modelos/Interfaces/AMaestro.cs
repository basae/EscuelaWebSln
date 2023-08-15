using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Interfaces
{
    public abstract class AMaestro:Persona
    {
        public abstract void MuestraNombre();
        public abstract void MuestraDireccion();
    }

    public abstract class AMaestro2
    {
        public abstract string MostrarCedula();        
    }
}
