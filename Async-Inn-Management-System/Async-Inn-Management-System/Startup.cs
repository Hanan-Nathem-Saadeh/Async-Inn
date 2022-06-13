using Async_Inn_Management_System.Controllers;
using Async_Inn_Management_System.Data;
using Async_Inn_Management_System.Models;
using Async_Inn_Management_System.Models.Interfaces;
using Async_Inn_Management_System.Models.Servieces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn_Management_System
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(
                options =>
                {
                    //options.Password.RequireDigit = false; // Adding digits to the password is not mandatory
                    options.User.RequireUniqueEmail = true; // make sure the email is unique

                }
                    )
                .AddEntityFrameworkStores<AsyncInnDbContext>();



            services.AddDbContext<AsyncInnDbContext>(options =>
            {

                string connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            
            });
            services.AddTransient<IAmentities, AmenitiesServieces>();
            services.AddTransient<IHotels, HotelServieces>();
            services.AddTransient<IRooms,RoomsServieces>();
            services.AddTransient<IHotelRoom, HotelRoomService>();
            services.AddTransient<IUserService, IdentityUserService>();
            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(options =>
               options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
           );
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("V1", new OpenApiInfo()
                {
                    Title = "Async-Inn-Manegment-System",
                    Version = "V1",
                });
            });
            services.AddScoped<JwtTokenService>();
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
   .AddJwtBearer(options =>
   {
       // Tell the authenticaion scheme "how/where" to validate the token + secret
       options.TokenValidationParameters = JwtTokenService.GetValidationParameters(Configuration);
   });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger(opt =>
            {
                opt.RouteTemplate = "/api/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/api/V1/swagger.json", "Async-Inn-Manegment-System");
                opt.RoutePrefix = "";
            });
          
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
