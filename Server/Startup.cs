using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using P7.Server.DB;
using Swashbuckle.AspNetCore.Swagger;
using System.Linq;

namespace P7.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            /* CORS */
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        }
        );
/* CORS */

            services.AddControllersWithViews();
            services.AddRazorPages();
            var sqlConnectionString="Host=ec2-54-243-92-68.compute-1.amazonaws.com;Database=d2v8lqd9t4uscv;Username=pbogezzpuamkdi;Port=5432;Password=52b213fe86925f15591f2adfd72676ad01cbb8db8def5a59ce12fd195e2a51cf;sslmode=Prefer;Trust Server Certificate=true;";

            // services.AddDbContext<ClothDbContext>(options => options.UseSqlServer(sqlConnectionString));
            // services.AddScoped<ClothProvider>();
            services.AddDbContext<ClothDbContext>(options => options.UseNpgsql(sqlConnectionString));
            services.AddScoped<ClothProvider>();

            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("a1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "API Title is",
                    Version = "a1"
                });
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();
            
            /* CORS-POLICY */
            app.UseCors("CorsPolicy");
            /* CORS-POLICY */


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");

            });
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/a1/swagger.json", "a1 api test");
            });
        }
    }
}
