using CapaNegocio;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using Modelos.Generico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace EscuelaWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioNegocio usuarioNegocio;

        public UsuarioController(IUsuarioNegocio usuarioNegocio)
        {
            this.usuarioNegocio = usuarioNegocio;
        }

        public ActionResult Index(string ReturnUrl = null)
        {
            TempData["ReturnUrl"] = ReturnUrl;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Index(Usuario usuario)
        {
            var respuestaNegocio = await usuarioNegocio.Login(usuario);
            if (respuestaNegocio.Error)
            {
                ModelState.AddModelError("Error al inicial sesión", respuestaNegocio.Message);
                return View(nameof(Index));
            }
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, respuestaNegocio.Result);
            if (TempData["ReturnUrl"] != null)
            {                
                return Redirect(TempData["ReturnUrl"].ToString());
            }
            return RedirectToAction("Index", "Escuela");
        }
        public ActionResult AccesoDenegado()
        {
            return View(nameof(AccesoDenegado));
        }
        public async Task<ActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
