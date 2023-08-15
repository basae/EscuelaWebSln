using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Generico
{
    public class RespuestaServicio<T>
    {
        public bool Error { get; set; }
        public string Message { get; set; }
        public T Result { get; set; } 
    }
}
