using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscuelaWeb.Seguridad
{
    public abstract class ModeloVistaBase<TModel> : RazorPage<TModel>
    {
        public virtual new UsuarioLogInOut User
        {
            get
            {                
                return new UsuarioLogInOut(base.User) ?? new UsuarioLogInOut();
            }
        } 
    }
}
