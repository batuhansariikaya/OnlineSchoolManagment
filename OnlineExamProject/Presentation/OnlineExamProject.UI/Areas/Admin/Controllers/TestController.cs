using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using OnlineExamProject.Application.Repositories;
using OnlineExamProject.Domain.Entities;
using OnlineExamProject.Persistence.Repositories;
using System;

namespace OnlineExamProject.UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class TestController : Controller
	{
		readonly private IQuestionReadRepository _questionRead;
		readonly private IQuestionWriteRepository _questionWrite;
		readonly private IDistributedCache _distributedCache;

		public TestController(IQuestionReadRepository questionRead, IQuestionWriteRepository questionWrite, IDistributedCache distributedCache)
		{
			_questionRead = questionRead;
			_questionWrite = questionWrite;
			_distributedCache = distributedCache;
		}

		public IActionResult Index()
		{
			
			return View();
		}
		//[HttpPost]
		//public IActionResult Index(Teacher t)
		//{
			
		

		//	return View();
		//}
		[HttpGet]
		public ActionResult Add()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Add(Question q)
		{
			_questionWrite.AddAsync(new Question
			{
				QuestionHeader="deneme",
				OptionA="a",
				OptionB="b",
				OptionC="c",
				OptionD="d",
				ExamId=3

			});

			_questionWrite.AddAsync(new Question
			{
				QuestionHeader="soru 2",
				ExamId=3				
			});
			_questionWrite.AddT(new Question
			{
				QuestionHeader = "soru 3",
				ExamId = 3
			});
			//_questionWrite.Commit();
			
			return View();
		}
		
	}
}
