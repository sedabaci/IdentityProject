using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvcCore();           //MVC uygulaması ile ilgili Core bileşenlerini kurar uygulama ayağa kalkarken patlar
            services.AddMvc();                //MVC uygulaması ile ilgili tüm bileşenleri kurar            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseDeveloperExceptionPage();      // sayfada hata alındıgında acıklayıcı bilgi sunuyor
            app.UseStatusCodePages();             // content dönmeyen sayfalarda acıklayıcı bilgi sunuyor
            app.UseStaticFiles();                 // js css gibi dosyaları yüklemek için
            app.UseEndpoints(endpoints =>
            {
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
                });
            });

            //app.UseMvcWithDefaultRoute();         // default  -- Controller/Action/{id}-- isimli route olusturur, manuel eklemeye gerek kalmaz
        }
    }
}
