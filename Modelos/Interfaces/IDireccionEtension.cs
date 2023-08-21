using Modelos.Generico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Interfaces
{
    public static class IDireccionEtension
    {
        public static void ValidarDatos(this IDireccion direccion)
        {
            if (direccion is null)
                throw new ArgumentNullException("objeto dirección invalido.");
            if (string.IsNullOrWhiteSpace(direccion.Colonia.Id))
                throw new ArgumentNullException("la colonia es requerida.");
            if (string.IsNullOrWhiteSpace(direccion.Calle))
                throw new ArgumentException("el nombre de la calle es requerido.");
            if (string.IsNullOrWhiteSpace(direccion.NoExt))
                throw new ArgumentNullException("número exterior requerido.");

        }
        public static void CastDireccionGenerica(this IDireccionGenerica dir,IDireccionGenerica dir2)
        {
            dir.Colonia = dir2.Colonia;
            dir.Municipio = dir2.Municipio;
            dir.Estado = dir2.Estado;
            dir.CodigoPostal = dir2.CodigoPostal;
        }
    }
}
