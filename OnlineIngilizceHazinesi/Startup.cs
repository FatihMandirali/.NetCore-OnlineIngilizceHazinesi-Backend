using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.KullanicilarService;
using Application.WordService;
using Core.DataBaseContext;
using Core.Repositories.KelimelerRepository;
using Core.Repositories.KullanicilarRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineIngilizceHazinesi
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddDbContext<OnlineDatabaseContext>(
           options => options.UseSqlServer(
               Configuration.GetConnectionString("OnlineIngilizceConnectionString")
               )
           );
            services.AddTransient(typeof(IKullanicilarAppService), typeof(KullanicilarAppService));
            services.AddTransient(typeof(IKullaniciRepository), typeof(KullaniciRepository));
            services.AddTransient(typeof(IWordAppService), typeof(WordAppService));
            services.AddTransient(typeof(IKelimeRepository), typeof(KelimeRepository));


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
