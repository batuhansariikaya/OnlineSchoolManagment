using Microsoft.Extensions.DependencyInjection;
using OnlineExamProject.Application.Abstractions.Hubs;
using OnlineExamProject.SignalR.HubServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.SignalR
{
	public static class ServiceRegistration
	{
		public static void AddSignalRServices(this IServiceCollection collection)
		{
			collection.AddTransient<IExamHubService, ExamHubServices>();
			collection.AddSignalR();
		}
	}
}
