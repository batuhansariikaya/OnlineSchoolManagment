using Microsoft.AspNetCore.SignalR;
using OnlineExamProject.Application.Abstractions.Hubs;
using OnlineExamProject.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.SignalR.HubServices
{
	public class ExamHubServices : IExamHubService
	{
		readonly IHubContext<ExamHub> _hubContext;
		public ExamHubServices(IHubContext<ExamHub> hubContext)
		{
			_hubContext = hubContext;
		}
		public async Task ProductAddedMessageAsync(string message)
		{
			await _hubContext.Clients.All.SendAsync("receiveExamAddedMessage", message);
		}
	}
}
