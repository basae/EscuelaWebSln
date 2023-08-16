using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Generico
{
    public interface IDatosControl
    {
        DateTime? FechaModificacion { get; set; }
        DateTime FechaRegistro { get; set; }
    }

    public class DatosControl : IDatosControl
    {
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
