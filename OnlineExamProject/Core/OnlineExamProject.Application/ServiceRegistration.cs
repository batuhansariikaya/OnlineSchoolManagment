using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using OnlineExamProject.Application.Repositories;
using OnlineExamProject.Application.Abstractions.Services;
using FluentValidation.AspNetCore;
using FluentValidation;
using OnlineExamProject.Application.DTOs.Grade;
using OnlineExamProject.Application.Validators.Grade;

namespace OnlineExamProject.Application
{
	public static class ServiceRegistration
	{
		public static void AddApplicationServices(this IServiceCollection collection)
		{
			collection.AddMediatR(typeof(ServiceRegistration));	
			collection.AddAutoMapper(typeof(ServiceRegistration));
			collection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			

		}
	}
}
