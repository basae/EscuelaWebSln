using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Estaticos
{
    public static class ConfiguracionApp
    { 
        public static IConfiguration Configuracion { get; set; }
    }
}
