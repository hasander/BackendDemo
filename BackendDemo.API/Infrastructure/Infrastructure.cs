using AutoMapper;
using BackendDemo.Core.Mapping;
using BackendDemo.Data.Base;
using BackendDemo.Data.Context;
using BackendDemo.ExceptionMiddleware;
using BackendDemo.SharedLibrary.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace BackendDemo.BorsaApi.Infrastructure
{
    public static class Infrastructure
    {

        public static IServiceCollection InstallServices(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddDependencies()
                .AddDbConnections(config)
                .AddJwtOptions(config)
                .AddSwaggerGen()
                .AddMappingConfig()
                .AddLogging();

            return services;
        }

        public static IApplicationBuilder InstallServicesApp(this IApplicationBuilder builder)
        {
            builder.UseExceptionMiddleware();
            return builder;
        }
        private static IServiceCollection AddDbConnections(this IServiceCollection services, IConfiguration _configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseNpgsql(_configuration.GetConnectionString("AppDb"));
            });
            return services;
        }

        private static IServiceCollection AddSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "JWTToken_Auth_API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            return services;
        }

        private static IServiceCollection AddJwtOptions(this IServiceCollection services, IConfiguration _configuration)
        {
            services.Configure<CustomTokenOptions>(_configuration.GetSection("TokenOptions"));

            var tokenOptions = _configuration.GetSection("TokenOptions").Get<CustomTokenOptions>();

            var key = Encoding.ASCII.GetBytes(tokenOptions.SecurityKey);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }

        private static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

            return services;
        }
        private static IServiceCollection AddMappingConfig(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }

    }
}
