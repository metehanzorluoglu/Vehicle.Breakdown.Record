using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using VehicleBreakdownListRecord.API.Filters;
using VehicleBreakdownRecor.Business.Concretes;
using VehicleBreakdownRecor.Business.Interfaces;
using VehicleBreakdownRecor.Business.Mapping;
using VehicleBreakdownRecor.Business.Validation;
using VehicleBreakdownRecord.DAL.Concretes;
using VehicleBreakdownRecord.DAL.Interfaces;
using VehicleBreakdownRecord.Entity.DTOs;
using VehicleBreakdownRecord.Entity.Entities;

namespace VehicleBreakdownListRecord.API
{
    public class Startup
    {
        /*     ToDoList
         *[x] Add Swagger
         *[x] Add MapProfile
         *[x] Add Filter Attribute for Validation
         *[ ] Add MiddleWare for Exeption
         *[ ] Add AutoFact Scopes
         */
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(option =>
            {
                option.Filters.Add(new ValidateFilterAttribute());
            })
                .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining(typeof(VehicleDtoValidator)))
                .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining(typeof(VehicleCommentDtoValidator)))
                .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining(typeof(BreakdownListDtoValidator)));

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddScoped<IBaseInterface<Vehicle>, VehicleRepository>();
            services.AddScoped<IBaseInterface<BreakdownList>, BreakdownListRepository>();
            services.AddScoped<IBaseBusiness<Vehicle>, VehicleBusiness>();
            services.AddScoped<IBaseBusiness<BreakdownListDto>, BreakdownListBusiness>();

            services.AddScoped<IVehicleBusiness, VehicleBusiness>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddSwaggerDocument();
            services.AddAutoMapper(typeof(MapProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
