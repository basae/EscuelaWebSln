using Microsoft.AspNetCore.Mvc;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscuelaWeb.Seguridad
{
    public class ControllerEscuelaWeb:Controller
    {
        protected virtual new UsuarioLogInOut User
        {
            get
            {
                return new UsuarioLogInOut(HttpContext.User);
            }
        }
    }
}
