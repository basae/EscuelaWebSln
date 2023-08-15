using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Interfaces
{
    public interface IAlumno: IPersona
    {
        public void MostrarDatosPersonales();
        public void MostrarDetalles();
    }
    public interface IAlumno2: IPersona
    {
        public string MostrarDireccion();
    }
}
