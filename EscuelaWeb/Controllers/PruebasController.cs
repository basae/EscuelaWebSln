using CapaDatos;
using CapaDatos.ConexionBD;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using Modelos.Generico;
using Modelos.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace EscuelaWeb.Controllers
{
    public class PruebasController : Controller
    {
        private readonly IEscuelaNegocio escuelaRepository;
        private readonly IDireccionNegocio direccion;

        public PruebasController(IEscuelaNegocio _escuela, IDireccionNegocio direccion)
        {
            escuelaRepository = _escuela;
            this.direccion = direccion;
        }
        public async Task<IActionResult> Index()
        {
            var Escuelas = await escuelaRepository.Obtener();
            if (Escuelas.Error)
                ModelState.AddModelError("Error de Carga", Escuelas.Message);
            return View("Index",Escuelas.Result);

        }
        public ActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Crear(Escuela escuela)
        {
            var Respuesta = await escuelaRepository.Guardar(escuela);
            if (Respuesta.Error)
            {
                ModelState.AddModelError("Error", Respuesta.Message);
                return View("Crear", escuela);
            }
            return RedirectToAction("Index");
        }
        public JsonResult ObtenerColonias(string CodigoPostal)
        {
            return Json(direccion.Obtener(CodigoPostal));
        }


    }
}
