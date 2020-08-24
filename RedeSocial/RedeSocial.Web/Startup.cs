using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using RedeSocial.Web.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RedeSocial.Domain.Account;
using Microsoft.AspNetCore.Authentication.Cookies;
using RedeSocial.Repository.Repository;
using RedeSocial.Domain.Account.Repository;
using RedeSocial.Service.Account;
using RedeSocial.Repository.Account;

namespace RedeSocial.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //Controle de conta e perfil
            services.AddTransient<IAccountRepository, AccountRepository>();//cria instancia do objeto por requisi;'ao
            services.AddTransient<IAccountService, AccountService>(); //reconhece o que injeta em cada camada de servi;o. Gerenciador da conta, criação/deleção/modificação
            services.AddTransient<IUserStore<Account>, AccountRepository>();
            services.AddTransient<IRoleStore<Profile>, ProfileRepository>();
            services.AddTransient<IAccountIdentityManager, AccountIdentityManager>(); //no controlador de conta vai ser possível injetar o seviço. sabe se o cara loga com sucesso

            //Set da identity que tem operador de conta e de perfil
            services.AddIdentity<Account, Profile>()
                 .AddDefaultTokenProviders(); 

            services.ConfigureApplicationCookie(options => //paginas de acesso
            {
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AcessDenied";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter; //retorno depois do login
            });




            services.AddControllersWithViews();

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
