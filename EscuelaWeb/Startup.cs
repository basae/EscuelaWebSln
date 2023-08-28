using CapaDatos;
using CapaDatos.ConexionBD;
using CapaNegocio;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Modelos;
using Modelos.Estaticos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            services.AddRazorPages().AddRazorRuntimeCompilation();          
            services.AddSingleton<IFabricaConexion>(x => new FabricaConexion("EscuelaWebConexion", x.GetService<IConfiguration>()));
            services.AddScoped<IAdministradorConexion, AdministradorConexion>();
            services.AddScoped<IConexionBase, ConexionBase>();
            services.AddScoped<IConexionBaseTransaction, ConexionBase>();

            CargaDependenciasNegocio(services);

            services.AddScoped<IEscuelaDatos, EscuelaDatos>();
            services.AddScoped<IDireccionDatos, DireccionDatos>();
            services.AddScoped<IUsuarioDatos, UsuarioDatos>();
            services.AddScoped<IContactoDatos, ContactoDatos>();

            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options=> Configuration.Bind("CookieSettings"));
            services.AddAuthentication(type => { 
                type.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                type.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                type.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
             .AddCookie(m => {
                 m.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Usuario/Index");
                 m.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Usuario/AccesoDenegado/....");                 
                 m.SlidingExpiration = true;
                 m.ExpireTimeSpan = TimeSpan.FromMinutes(120);                
             })
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                                Encoding.ASCII.GetBytes(Configuration["JWT:ClaveSecreta"])
                            ),
                        ClockSkew = TimeSpan.Zero                        
                    };
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;                   
                });

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
            app.UseAuthentication();
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
            services.AddScoped<IEscuelaNegocio, EscuelaNegocio>();
            services.AddScoped<IDireccionNegocio, DireccionNegocio>();
            services.AddScoped<IUsuarioNegocio, UsuarioNegocio>();
            services.AddScoped<IContactoNegocio, ContactoNegocio>();
        }
    }
}
