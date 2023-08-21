using Modelos.Generico;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Escuela
    {
        public int? Id { get; set; }
        [DisplayName(displayName:"Identificador")]
        public string Clave { get; set; }
        public string Nombre { get; set; }
        [DisplayName(displayName:"Año de registro")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Anioregistro { get; set; }
        [DisplayName(displayName: "Nivel educativo")]
        public Catalogo NivelEducativo { get; set; } = new Catalogo();        
        public Direccion Direccion { get; set; } = new Direccion();
        [DisplayName(displayName: "Estado del registro")]
        public Catalogo EstadoReg { get; set; } = new Catalogo();
        public Usuario Usuario { get; set; } = new Usuario();
        [DisplayName(displayName: "Ultimo cambio")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? FechaModificacion { get; set; }
        [DisplayName(displayName: "Fecha de registro")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime FechaRegistro { get; set; }
        [DisplayName(displayName: "Contacto")]
        public Contacto Contacto { get; set; } = new Contacto();

    }
}
