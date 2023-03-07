using OnlineExamProject.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Application.DTOs.Configuration
{
	public class Action
	{
		/// <summary>
		/// action'ın tipi 
		/// </summary>
		public string ActionType	 { get; set; }
		/// <summary>
		/// get post put delete
		/// </summary>
		public string HttpType	 { get; set; }
		/// <summary>
		/// action ne işe yarıyor
		/// </summary>
		public string Definition	 { get; set; }
		public string Code	 { get; set; }
	}
}
