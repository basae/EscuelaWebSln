using CapaDatos;
using CapaDatos.ConexionBD;
using CapaNegocio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Modelos.Estaticos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscuelaWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ConfiguracionApp.Configuracion = Configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddSingleton<IFabricaConexion>(x => new FabricaConexion("EscuelaWebConexion", x.GetService<IConfiguration>()));
            services.AddScoped<IAdministradorConexion, AdministradorConexion>();
            services.AddScoped<IConexionBase, ConexionBase>();
            services.AddScoped<IConexionBaseTransaction, ConexionBase>();
            
            CargaDependenciasNegocio(services);   
            
            services.AddScoped<EscuelaDatos, EscuelaDatos>();
            services.AddScoped<DireccionDatos, DireccionDatos>();
                                
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public void CargaDependenciasNegocio(IServiceCollection services)
        {
            services.AddScoped<EscuelaNegocio, EscuelaNegocio>();
            services.AddScoped<DireccionNegocio, DireccionNegocio>();
        }
    }
}
