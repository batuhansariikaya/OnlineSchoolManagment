using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineExamProject.Application.Abstractions.Services;
using OnlineExamProject.Application.Repositories;
using OnlineExamProject.Application.Validators;
using OnlineExamProject.Application.Validators.CustomValidations;
using OnlineExamProject.Domain.Entities.Identity;
using OnlineExamProject.Persistence.Contexts;
using OnlineExamProject.Persistence.Repositories;
using OnlineExamProject.Persistence.Services;
using StackExchange.Redis;
using System.IO;


namespace OnlineExamProject.Persistence
{
	public static class ServiceRegistration
	{
		public static void AddPersistenceServices(this IServiceCollection services)
		{ 

			ConfigurationManager configurationManager = new();
			configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/OnlineExamProject.UI"));
			configurationManager.AddJsonFile("appsettings.json");

			services.AddDbContext<OnlineExamProjectDbContext>(options => options.UseSqlServer(configurationManager.GetConnectionString("SQLServer")));

          


            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequireNonAlphanumeric=false;
                opt.User.RequireUniqueEmail = true;// emailler tekil olsun
                opt.User.AllowedUserNameCharacters = "abcçdefghiıjklmnoöpqrsştuüvwxyzABCÇDEFGHIİJKLMNOÖPQRSŞTUÜVWXYZ0123456789-._"; //kullanıcı adında geçerli olacak karakterler.

            }).AddPasswordValidator<CustomPasswordValidator>()
             .AddUserValidator<CustomUserValidator>()
            .AddRoleManager<RoleManager<AppRole>>()
			.AddEntityFrameworkStores<OnlineExamProjectDbContext>();
			services.AddMemoryCache();



			services.AddScoped<IQuestionReadRepository,QuestionReadRepository>();
			services.AddScoped<IQuestionWriteRepository,QuestionWriteRepository>();
			services.AddScoped<ITeacherReadRepository,TeacherReadRepository>();
			services.AddScoped<ITeacherWriteRepository,TeacherWriteRepository>();
			services.AddScoped<IExamReadRepository,ExamReadRepository>();
			services.AddScoped<IExamWriteRepository,ExamWriteRepository>();
			services.AddScoped<IRoleService, RoleService>();		
			services.AddScoped<IAuthorizationEndpointService,AuthorizationEndpointService>();
            services.AddScoped<IMenuReadRepository, MenuReadRepository>();
            services.AddScoped<IMenuWriteRepository, MenuWriteRepository>();
            services.AddScoped<IEndpointReadRepository, EndpointReadRepository>();
            services.AddScoped<IEndpointWriteRepository, EndpointWriteRepository>();

            services.AddScoped<IGradeReadRepository, GradeReadRepository>();
            services.AddScoped<IGradeWriteRepository, GradeWriteRepository>();
            
            services.AddScoped<IUserService, UserService>();
			services.AddScoped<IGetUserInfo, GetUserInfo>();
            services.AddHttpContextAccessor();



        }
    }
}
