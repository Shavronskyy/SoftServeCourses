using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SoftServeTestTask_BLL.DTO.Account;
using SoftServeTestTask_DAL.Database;
using SoftServeTestTask_WebAPI.Extensions;
using Swashbuckle.AspNetCore.Filters;

namespace SoftServeTestTask_WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddDbContext<CoursesDbContext>(options =>
            options.UseSqlServer(builder.Configuration["DefaultConnection:ConnectionString"]));

            builder.Services.AddSwaggerGen(opt =>
            {
                opt.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                opt.OperationFilter<SecurityRequirementsOperationFilter>();
            });
            builder.Services.AddCustomService();
            builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("ApiSettings:JwtOptions"));
            builder.Services.AddCustomRepositories();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
