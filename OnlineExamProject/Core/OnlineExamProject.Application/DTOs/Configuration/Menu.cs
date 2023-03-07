using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Application.DTOs.Configuration
{
	public class Menu
	{
		/// <summary>
		/// controller'ın adı
		/// </summary>
		public string  Name { get; set; }
		public List<Action> Actions { get; set; } = new();
	}
}
