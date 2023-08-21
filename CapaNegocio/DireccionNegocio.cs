using CapaDatos;
using Modelos.Generico;
using Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class DireccionNegocio : IDireccionNegocio
    {
        private readonly IDireccionDatos direccionDatos;

        public DireccionNegocio(IDireccionDatos direccionDatos)
        {
            this.direccionDatos = direccionDatos;
        }

        public async Task<RespuestaServicio<int?>> Guardar(Direccion direccion)
        {
            RespuestaServicio<int?> respuesta = new RespuestaServicio<int?>();
            try
            {
                direccion.ValidarDatos();
                respuesta = direccionDatos.Guardar(direccion);
            }
            catch (Exception ex)
            {
                respuesta.Error = true;
                respuesta.Message = ex.Message;
            }
            return respuesta;
        }
        public RespuestaServicio<IEnumerable<DireccionGenerica>> Obtener(string CodigoPostal)
        {
            RespuestaServicio<IEnumerable<DireccionGenerica>> respuesta = new RespuestaServicio<IEnumerable<DireccionGenerica>>();
            try
            {
                if (string.IsNullOrWhiteSpace(CodigoPostal))
                    throw new ArgumentNullException("el código postal es requerido");
                respuesta = direccionDatos.Obtener(CodigoPostal);
            }
            catch (Exception ex)
            {
                respuesta.Error = true;
                respuesta.Message = ex.Message;
            }
            return respuesta;
        }
    }
}
