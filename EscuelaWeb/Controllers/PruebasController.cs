using CapaDatos;
using CapaDatos.ConexionBD;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using Modelos.Generico;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace EscuelaWeb.Controllers
{
    public class PruebasController : Controller
    {
        private readonly EscuelaNegocio escuelaRepository;
        private readonly DireccionNegocio direccion;

        public PruebasController(EscuelaNegocio _escuela, DireccionNegocio direccion)
        {
            escuelaRepository = _escuela;
            this.direccion = direccion;
        }
        public IActionResult Index()
        {

            //Escuela escuela = new Escuela();
            //escuela.Clave = "ABCD123456";
            //escuela.Nombre = "Universidad X";
            //escuela.Telefono = "555555555";
            //escuela.Anioregistro = new DateTime(1989, 10, 22);
            //var colonias = direccion.Obtener("96400");
            //escuela.Direccion.CastDireccionGenerica(colonias.Result.First());
            //escuela.NivelEducativo = new Catalogo { Id = "4" };
            //escuela.Direccion.Calle = "RIO MISSISIPI";
            //escuela.Direccion.NoExt = "160";
            var respuesta = escuelaRepository.Obtener(1);
            if (respuesta.Error)
                return BadRequest(respuesta.Message);
            var test = JsonConvert.SerializeObject(respuesta.Result, settings: new JsonSerializerSettings { Formatting = Formatting.Indented });
            return View("Index",test);
            
        }
    }
}
