using CapaDatos;
using CapaDatos.ConexionBD;
using CapaNegocio;
using EscuelaWeb.Seguridad;
using Microsoft.AspNetCore.Authorization;
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
    public class EscuelaController : ControllerEscuelaWeb
    {
        private readonly IEscuelaNegocio escuelaRepository;
        private readonly IDireccionNegocio direccion;

        public EscuelaController(IEscuelaNegocio _escuela, IDireccionNegocio direccion)
        {
            escuelaRepository = _escuela;
            this.direccion = direccion;
        }
        //[HttpGet] SOLO SE UTILIZA PARA CONSULTA DE INFORMACION (VISUALIZAR PAGINA)
        //[HttpPost] SOLO SE UTILIZA PARA ENVIAR INFORMACION EN MODELOS DE DATOS()
        //[HttpPut] SOLO SE DEBE UTILIZAR PARA ACTUALIZAR DATOS
        //[HttpDelete] SOLO ES PARA ELMINAR INFORMACION (DEPENDED LA LOGICA PUEDE SER ELIMINACION LOGICA O FISICA)
        public async Task<IActionResult> Index()
        {
            List<Escuela> Escuelas = new();
            if (User.Autenticado)
            {
                switch (User.TipoAut)
                {
                    case TypeAuth.ADMIN:
                        var respuestaEscuela = await escuelaRepository.Obtener();
                        if (respuestaEscuela.Error)
                            ModelState.AddModelError("Error de Carga", respuestaEscuela.Message);
                        Escuelas = respuestaEscuela.Result.ToList();
                        break;
                    default:
                        var respuestaEscuelaSingle = await escuelaRepository.Obtener(Convert.ToInt32(User.Id_Entidad));
                        if (respuestaEscuelaSingle.Error)
                            ModelState.AddModelError("Error de Carga", respuestaEscuelaSingle.Message);
                        Escuelas.Add(respuestaEscuelaSingle.Result);
                        break;
                }
            }
            return View("Index", Escuelas);


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
