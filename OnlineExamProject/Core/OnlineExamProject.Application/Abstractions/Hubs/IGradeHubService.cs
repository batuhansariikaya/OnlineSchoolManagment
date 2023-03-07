using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Application.Abstractions.Hubs
{
    public interface IGradeHubService
    {
        Task GradeAddMessageAsync(string message);
    }
}
