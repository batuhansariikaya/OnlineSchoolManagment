using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using OnlineExamProject.Application.Abstractions.Services.Configuration;
using OnlineExamProject.Application.CustomAttributes;
using OnlineExamProject.Application.Enums;
using OnlineExamProject.Application.Repositories;
using OnlineExamProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Endpoint = OnlineExamProject.Domain.Entities.Endpoint;

namespace OnlineExamProject.Infrastructure.Services.Configuration
{
	public  class ApplicationService : IApplicationService
	{
		readonly IEndpointReadRepository _endpointReadRepository;
		readonly IEndpointWriteRepository _endpointWriteRepository;
		readonly IMenuReadRepository _menuReadRepository;
		readonly IMenuWriteRepository _menuWriteRepository;

        public ApplicationService(IEndpointWriteRepository endpointWriteRepository, IMenuWriteRepository menuWriteRepository, IMenuReadRepository menuReadRepository, IEndpointReadRepository endpointReadRepository)
        {
            _endpointWriteRepository = endpointWriteRepository;
            _menuWriteRepository = menuWriteRepository;
            _menuReadRepository = menuReadRepository;
            _endpointReadRepository = endpointReadRepository;
        }

        public async Task<List<Menu>> GetAuthorizeDefinitionEndpoints(Type type)
		{ 
			Menu menu=null;
			Endpoint endpoints = null;
			var menus = _menuReadRepository.GetAll();
			var _actions = _endpointReadRepository.GetAll();
			Assembly assembly = Assembly.GetAssembly(type);  // assembly getirir
			var controllers = assembly.GetTypes().Where(t=>t.IsAssignableTo(typeof(Controller))); // controller sınıfınan türeyenler 
            if (controllers != null)
            {
				foreach(var controller in controllers)
                {
					var actions=controller.GetMethods().Where(x=>x.IsDefined(typeof(AuthorizeDefinitionAttribute))); // bunula işaretli olan methodlar yani actionlar geliyor
                    if (actions!=null)
                    {
						foreach(var action in actions)
                        {
							var attributes = action.GetCustomAttributes(true);   // custom attributeları getir
							if(attributes!=null)
                            {
								var authorizeAttirbute= attributes.FirstOrDefault(a => a.GetType() == typeof(AuthorizeDefinitionAttribute)) as AuthorizeDefinitionAttribute;
                                // authorizeAttirbute.Menu  controller adı
                                // authorizeAttirbute.Definition açıklama
                                // authorizeAttirbute.ActionType  action tip
                                if (!menus.Any(m => m.Name == authorizeAttirbute.Menu))
                                {									
                                        await _menuWriteRepository.AddAsync(new()
                                        {
                                            Name = authorizeAttirbute.Menu
                                        });
                                        await _menuWriteRepository.SaveAsync();                                 								
									menu = _menuReadRepository.GetAll().FirstOrDefault(m => m.Name == authorizeAttirbute.Menu);
									
								}
                                else
                                {
									  menu=_menuReadRepository.GetAll().FirstOrDefault(m => m.Name == authorizeAttirbute.Menu);
                                }
								Domain.Entities.Endpoint _action = new()
								{
									Definition = authorizeAttirbute.Definition,
									ActionType= Enum.GetName(typeof(ActionType), authorizeAttirbute.ActionType),
									CreatedDate=DateTime.Now,
									UpdatedDate=DateTime.Now,
									Status=true,
									Name=authorizeAttirbute.Definition																										
								};
								
								var httpAttribute=attributes.FirstOrDefault(a => a.GetType().IsAssignableTo(typeof(HttpMethodAttribute))) as HttpMethodAttribute;
                                if (httpAttribute != null)
                                {
									_action.HttpType = httpAttribute.HttpMethods.First();
                                }
                                else
                                {
									_action.HttpType = HttpMethods.Get;
                                }
                                if (!_actions.Any(a => a.Name == _action.Name))
                                {
                                    _action.Code = $"{_action.HttpType}.{_action.ActionType}.{_action.Definition.Replace(" ", "")}";
                                    _action.MenuId = menu.Id;
                                    await _endpointWriteRepository.AddAsync(_action);
                                    await _endpointWriteRepository.SaveAsync();
                                }
								else
								{
									endpoints= _endpointReadRepository.GetAll().FirstOrDefault(e=>e.Name == _action.Name);
                                }
                            }
                        }
                    }
				}
            }
			return menus.ToList();

		}














		//			var data = _menuReadRepository.GetAll();
		//Assembly assembly = Assembly.GetAssembly(type); // o anki calisan assembly'i dondurur.  getExecutingAssembly
		//var controllers = assembly.GetTypes().Where(t => t.IsAssignableTo(typeof(Controller))); //sistemdeki tum type'lara erisebiliyoruz
		//																						//			List<Menu> menus = new();
		//if (controllers != null)
		//	foreach (var controller in controllers)
		//             {
		//                 if (data == null)
		//                 {
		//			var _controller = _menuWriteRepository.AddAsync(new()
		//			{
		//				Name = controller.Name,
		//				Status = true,
		//				CreatedDate = DateTime.Now,
		//				UpdatedDate = DateTime.Now
		//			});
		//			_menuWriteRepository.SaveAsync();
		//		}
		//                 else
		//                 {
		//			_menuWriteRepository.Remove(controller);
		//                 }

		//		Menu controllerId=_menuReadRepository.GetIdInfo(menu.Id);					


		//		var actions = controller.GetMethods().Where(x => x.IsDefined(typeof(AuthorizeDefinitionAttribute)));
		//		if (actions != null)
		//			foreach (var action in actions)
		//			{
		//				var attributes = action.GetCustomAttributes(true);
		//				if (attributes != null)
		//				{
		//					//Menu menu = null;
		//					var authorizeDefinitionAttribute = attributes.FirstOrDefault(a => a.GetType() == typeof(AuthorizeDefinitionAttribute)) as AuthorizeDefinitionAttribute;
		//					object actionName;
		//					if (!data.Any(x => x.Name == authorizeDefinitionAttribute.Menu))
		//					{
		//						 actionName = _endpointWriteRepository.AddAsync(new()
		//						{
		//							Name = authorizeDefinitionAttribute.Menu,
		//						});
		//						//menu = new() { Name = authorizeDefinitionAttribute.Menu };
		//						//menus.Add(menu);
		//					}
		//					else
		//					{
		//						 actionName = data.FirstOrDefault(c => c.Name == authorizeDefinitionAttribute.Menu);

		//						//menu = menus.FirstOrDefault(m => m.Name == authorizeDefinitionAttribute.Menu);
		//					}
		//					Domain.Entities.Endpoint _action = new()
		//					{

		//					};
		//					var httpAttribute = attributes.FirstOrDefault(a => a.GetType().IsAssignableTo(typeof(HttpMethodAttribute))) as HttpMethodAttribute;
		//					if (httpAttribute != null)
		//					{
		//						_action.HttpType = httpAttribute.HttpMethods.First();
		//					}
		//					else
		//					{
		//						_action.HttpType = HttpMethods.Get;
		//					}
		//					//_action.Code = $"{_action.HttpType}.{_action.ActionType}.{_action.Definition.Replace(" ", "")}";
		//					//_action.Code = $"{_action.Name}";
		//					//_action.Status = true;
		//					//_action.CreatedDate = DateTime.Now;
		//					//_action.UpdatedDate = DateTime.Now;

		//                             _endpointWriteRepository.AddAsync(new()
		//                             {
		//						ActionType = Enum.GetName(typeof(ActionType), authorizeDefinitionAttribute.ActionType),
		//						Definition = authorizeDefinitionAttribute.Definition,
		//						Status = true,
		//						Name = actionName.ToString(),
		//						MenuId = Convert.ToInt32(controllerId),
		//						Code= $"{_action.Name}",
		//						CreatedDate=DateTime.Now,
		//						UpdatedDate=DateTime.Now									
		//				});
		//					_endpointWriteRepository.SaveAsync();

		//					//menu.Actions.Add(_action);
		//				}




		//			}
		//	}

		////return menus;

		//return data.ToList();




	}
}
