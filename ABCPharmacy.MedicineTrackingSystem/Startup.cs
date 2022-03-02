using ABCPharmacy.MedicineTrackingSystem.Application;
using ABCPharmacy.MedicineTrackingSystem.Application.Infrastructure.Behaviours;
using ABCPharmacy.MedicineTrackingSystem.Application.Medicine.Services;
using GlobalExceptionHandler.WebApi;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace ABCPharmacy.MedicineTrackingSystem.API
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
            services.Configure<ApplicationSettings>(options =>
            {
                Configuration.GetSection("AppSettings").Bind(options);
            });

            services.AddSingleton(resolver =>
            {
                return resolver.GetRequiredService<IOptions<ApplicationSettings>>().Value;
            });
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ABC Pharmacy Medicine Tracking System",
                    Description = "ABC Pharmacy Medicine Tracking System Swagger interface",
                    Contact = new OpenApiContact { },
                });
            });

            services.AddMediatR(typeof(ApplicationSettings).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient<IMedicineStockService, MedicineStockService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseGlobalExceptionHandler(cfg => cfg.MapExceptions());
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Connect Self Serve Management API (v1)");
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
