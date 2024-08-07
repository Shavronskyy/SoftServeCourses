using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SoftServeTestTask_BLL.Services.Interfaces.CourseServices;
using SoftServeTestTask_BLL.Services.Realizations.CourseServices;
using SoftServeTestTask_DAL.Database;
using SoftServeTestTask_DAL.Repositories.Interfaces.CourseRep;
using SoftServeTestTask_DAL.Repositories.Interfaces.StudentRep;
using SoftServeTestTask_DAL.Repositories.Interfaces.TeacherRep;
using SoftServeTestTask_DAL.Repositories.Realizations.CourseRep;
using SoftServeTestTask_DAL.Repositories.Realizations.StudentRep;
using SoftServeTestTask_DAL.Repositories.Realizations.TeacherRep;
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

            builder.Services.AddSwaggerGen();
            builder.Services.AddCustomService();
            builder.Services.AddCustomRepositories();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseAuthentication();
            app.MapControllers();

            app.Run();
        }
    }
}
