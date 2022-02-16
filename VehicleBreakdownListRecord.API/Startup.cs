using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using VehicleBreakdownListRecord.API.Filters;
using VehicleBreakdownListRecord.API.Middlewares;
using VehicleBreakdownRecor.Business.Concretes;
using VehicleBreakdownRecor.Business.Interfaces;
using VehicleBreakdownRecor.Business.Mapping;
using VehicleBreakdownRecor.Business.Services;
using VehicleBreakdownRecor.Business.TokenConfiguration;
using VehicleBreakdownRecor.Business.Validation;
using VehicleBreakdownRecord.DAL;
using VehicleBreakdownRecord.DAL.Concretes;
using VehicleBreakdownRecord.DAL.Interfaces;
using VehicleBreakdownRecord.DAL.Repositories;
using VehicleBreakdownRecord.Entity.Configurations;
using VehicleBreakdownRecord.Entity.DTOs;
using VehicleBreakdownRecord.Entity.Entities;
using VehicleBreakdownRecord.Entity.Interfaces;
using VehicleBreakdownRecord.Entity.Services;
using VehicleBreakdownRecord.Entity.UnitOfWork;

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
            //Options Pattern
            services.Configure<CustomTokenOption>(Configuration.GetSection("TokenOption"));
            services.Configure<List<Client>>(Configuration.GetSection("Clients"));

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

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

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

            services.AddIdentity<UserApp, IdentityRole>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                opt.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, option =>
            {
                var tokenOptions = Configuration.GetSection("TokenOption").Get<CustomTokenOption>();
                option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience=tokenOptions.Audience[0],
                    IssuerSigningKey=SignService.GetSymmetricSecurityKey(tokenOptions.SecurityKey),

                    ValidateIssuerSigningKey=true,
                    ValidateAudience=true,
                    ValidateIssuer=true,
                    ValidateLifetime=true,
                    ClockSkew=TimeSpan.Zero

                };
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
