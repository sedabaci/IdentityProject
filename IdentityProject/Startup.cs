using IdentityProject.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProject
{
    public class Startup
    {
        public IConfiguration configuration { get; }
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppIdentityDbContext>(opts =>
            {
                opts.UseSqlServer(configuration["ConnectionStrings:DefaultConnectionString"]);

            });

            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>();  //AppIdentityDbContext'e kaydet
            services.AddMvc();                       //MVC uygulaması ile ilgili tüm bileşenleri kurar
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseDeveloperExceptionPage();         // sayfada hata alındıgında acıklayıcı bilgi sunuyor
            app.UseStatusCodePages();                // content dönmeyen sayfalarda acıklayıcı bilgi sunuyor
            app.UseStaticFiles();                    // js css gibi dosyaları yüklemek için
            app.UseAuthentication();                 // Identity mekanizması kullanacağım için ekliyorum.
            app.UseEndpoints(endpoints =>
            {
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
                });
            });
            //app.UseMvcWithDefaultRoute();          // default  --Controller/Action/{id}-- isimli route olusturur, manuel eklemeye gerek kalmaz
        }
    }
}
