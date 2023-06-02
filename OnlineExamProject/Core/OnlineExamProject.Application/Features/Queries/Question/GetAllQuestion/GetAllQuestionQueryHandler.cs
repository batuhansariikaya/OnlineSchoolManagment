using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using OnlineExamProject.Application.Abstractions.Services;
using OnlineExamProject.Application.Repositories;
using OnlineExamProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineExamProject.Application.Features.Queries.Question.GetAllQuestion
{
	public class GetAllQuestionQueryHandler : IRequestHandler<GetAllQuestionQueryRequest, IQueryable<Exam>>
	{
		readonly IQuestionReadRepository _questionReadRepository;
		readonly IExamReadRepository _examReadRepository;
		readonly IDistributedCache _distributedCache;
		readonly IUserService _userService;
   

        public GetAllQuestionQueryHandler(IQuestionReadRepository questionReadRepository, IExamReadRepository examReadRepository, IUserService userService)
		{
			_questionReadRepository = questionReadRepository;
			_examReadRepository = examReadRepository;
            _userService = userService;
        }

		public async Task<IQueryable<Exam>> Handle(GetAllQuestionQueryRequest request, CancellationToken cancellationToken)
		{
			//var cacheData = _distributedCache.GetStringAsync("examList");
			//if (cacheData != null)
			//{
			//	var datas = _examReadRepository.GetAll().Select(x => new Exam()
			//	{
			//		Id = x.Id,
			//		Name = x.Name,
			//		Description = x.Description

			//	});
			//	if (datas.Any())
			//	{
			//		await _distributedCache.SetStringAsync("examList", datas.ToString());
			//		return datas;
			//	}
			//	return datas;
			//}
			//else
			//{
			//	var data = await _distributedCache.GetStringAsync("examList");
			//	return 
			//}

			var datas = _examReadRepository.GetAll().Select(x => new Exam()
			{
				Id = x.Id,
				Name = x.Name,
				Description = x.Description,
				UserId=x.UserId
			});
			return datas;
		}		

	}
}
