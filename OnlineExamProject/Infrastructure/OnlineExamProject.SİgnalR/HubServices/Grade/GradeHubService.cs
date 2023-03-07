using Microsoft.AspNetCore.SignalR;
using OnlineExamProject.Application.Abstractions.Hubs;
using OnlineExamProject.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.SignalR.HubServices.Grade
{
    public class GradeHubService : IGradeHubService
    {
        private readonly IHubContext<GradeHub> _hubContext;
        public async Task GradeAddMessageAsync(string message)
        {
            await _hubContext.Clients.All.SendAsync("sendGradeMessage",message);
        }
    }
}
