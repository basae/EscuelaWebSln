using CapaDatos;
using Modelos;
using Modelos.Generico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ContactoNegocio : IContactoNegocio
    {
        private readonly IContactoDatos contactoDatos;

        public ContactoNegocio(IContactoDatos contactoDatos)
        {
            this.contactoDatos = contactoDatos;
        }
        public async Task<RespuestaServicio<int>> Crear(Contacto contacto)
        {            
            RespuestaServicio<int> respuesta = new();
            try
            {
                contacto.ValidaContacto();
                respuesta = contactoDatos.Crear(contacto);
            }
            catch (Exception ex)
            {
                respuesta.Error = true;
                respuesta.Message = ex.Message;
            }
            return respuesta;
        }
        public RespuestaServicio<int> Modificar(int id, Contacto contacto)
        {
            RespuestaServicio<int> respuesta = new();
            try
            {
                if (id < 1)
                    throw new Exception("id invalido");
                respuesta = contactoDatos.Modificar(id, contacto);
            }
            catch (Exception ex)
            {
                respuesta.Error = true;
                respuesta.Message = ex.Message;
            }
            return respuesta;
        }
        public RespuestaServicio<Contacto> Obtener(int id)
        {
            RespuestaServicio<Contacto> respuesta = new();
            try
            {
                if (id < 1)
                    throw new Exception("id invalido");
                respuesta = contactoDatos.Obtener(id);
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
