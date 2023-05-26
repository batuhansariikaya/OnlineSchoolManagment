using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using OnlineExamProject.Application.Abstractions.Services.Configuration;
using OnlineExamProject.Infrastructure.Services.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OnlineExamProject.Infrastructure
{
    public static class ServiceRegistration
	{
		public static void AddInfrastructureServices( this IServiceCollection services)
		{
			services.AddScoped<IApplicationService, ApplicationService>();
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost:6379";
            });


        }
	}
}
