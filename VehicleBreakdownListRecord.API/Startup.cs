using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VehicleBreakdownListRecord.API.Filters;
using VehicleBreakdownListRecord.API.Middlewares;
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
         *[x] Add MiddleWare for Exeption
         *[ ] Add AutoFact Scopes
         *[ ] Search InvalidModelStateResponseFactory
         *[ ] Delegate Function 
         *[x] json Patch 
         *[ ] Web Soccet
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
                .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining(typeof(BreakdownListDtoValidator)))
                .AddNewtonsoftJson();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            services.AddFluentValidation(conf =>
            {
                conf.DisableDataAnnotationsValidation = true;
                conf.ImplicitlyValidateChildProperties = true;

            });
            services.AddScoped<IBaseInterface<Vehicle>, VehicleRepository>();
            services.AddScoped<IBaseInterface<BreakdownList>, BreakdownListRepository>();
            services.AddScoped<IBaseInterface<VehicleComment>, VehicleCommentRepository>();

            services.AddScoped<IBaseBusiness<Vehicle>, VehicleBusiness>();
            services.AddScoped<IBaseBusiness<BreakdownListDto>, BreakdownListBusiness>();
            services.AddScoped<IBaseBusiness<VehicleCommentDto>, VehicleCommentBusiness>();

            services.AddScoped<IVehicleBusiness, VehicleBusiness>();
            services.AddScoped<IVehicleCommentBusiness, VehicleCommentBusiness>();
            services.AddScoped<IBreakdownListBusiness, BreakdownListBusiness>();

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

            app.UseCustomException();
            //app.UseExceptionHandler(appError =>
            //{
            //    appError.Run(async context =>
            //    {
            //        var error = context.Features.Get<IExceptionHandlerFeature>();
            //        if (error!=null)
            //        {
            //            await context.Response.WriteAsync(JsonConvert.SerializeObject(
            //                new
            //                {
            //                    ResponseMessage = env.IsDevelopment() ? error.ToString() : "Internal Server Error!"
            //                }));
            //        }
            //    });

            //});
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
