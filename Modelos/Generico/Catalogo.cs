using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Generico
{
    public class Catalogo
    {
        public string Id { get; set; }
        public string Descripcion { get; set; }
        public Catalogo() { }

        public Catalogo(string id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion ?? throw new ArgumentNullException(nameof(descripcion));
        }
    }
}
