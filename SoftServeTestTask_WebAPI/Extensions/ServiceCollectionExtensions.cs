using SoftServeTestTask_BLL.Services.Interfaces.CourseServices;
using SoftServeTestTask_BLL.Services.Interfaces.StudentServices;
using SoftServeTestTask_BLL.Services.Interfaces.TeacherServices;
using SoftServeTestTask_BLL.Services.Realizations.CourseServices;
using SoftServeTestTask_BLL.Services.Realizations.StudentServices;
using SoftServeTestTask_BLL.Services.Realizations.TeacherServices;
using SoftServeTestTask_DAL.Repositories.Interfaces.CourseRep;
using SoftServeTestTask_DAL.Repositories.Interfaces.StudentRep;
using SoftServeTestTask_DAL.Repositories.Interfaces.TeacherRep;
using SoftServeTestTask_DAL.Repositories.Realizations.CourseRep;
using SoftServeTestTask_DAL.Repositories.Realizations.StudentRep;
using SoftServeTestTask_DAL.Repositories.Realizations.TeacherRep;
using SoftServeTestTask_DAL.Repositories.Realizations.Account;
using FluentValidation.AspNetCore;
using SoftServeTestTask_BLL.Validation;
using Microsoft.AspNetCore.Identity;
using SoftServeTestTask_DAL.Database;
using SoftServeTestTask_DAL.Entities.Account;
using SoftServeTestTask_BLL.Services.Interfaces.Account;
using SoftServeTestTask_BLL.Services.Realizations.Account;
using SoftServeTestTask_DAL.Repositories.Interfaces.AccountRep;



namespace SoftServeTestTask_WebAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomService(this IServiceCollection services)
        {
            var currentAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            services.AddAutoMapper(currentAssemblies);

            //Services
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddAuthentication();
            services.AddAuthorization();

            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<CoursesDbContext>()
                    .AddDefaultTokenProviders();

            

            //Validation
            services.AddControllers().AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblyContaining<CreateCourseValidation>();
                fv.RegisterValidatorsFromAssemblyContaining<UpdateCourseValidation>();
                fv.RegisterValidatorsFromAssemblyContaining<CreateStudentValidation>();
                fv.RegisterValidatorsFromAssemblyContaining<UpdateStudentValidation>();
                fv.RegisterValidatorsFromAssemblyContaining<CreateTeacherValidation>();
                fv.RegisterValidatorsFromAssemblyContaining<UpdateTeacherValidation>();
            });

            return services;
        }
        public static void AddCustomRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
        }
    }
}
