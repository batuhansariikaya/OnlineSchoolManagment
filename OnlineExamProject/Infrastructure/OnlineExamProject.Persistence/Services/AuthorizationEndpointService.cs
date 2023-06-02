using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineExamProject.Application.Abstractions.Services;
using OnlineExamProject.Application.Abstractions.Services.Configuration;
using OnlineExamProject.Application.Repositories;
using OnlineExamProject.Domain.Entities;
using OnlineExamProject.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Persistence.Services
{
	public class AuthorizationEndpointService : IAuthorizationEndpointService
	{
		readonly IApplicationService _applicationService;		
		readonly RoleManager<AppRole> _roleManager;
        readonly IMenuReadRepository _menuReadRepository;
        readonly IMenuWriteRepository _menuWriteRepository;
        readonly IEndpointReadRepository _endpointReadRepository;
        readonly IEndpointWriteRepository _endpointWriteRepository;

        public AuthorizationEndpointService(IApplicationService applicationService, RoleManager<AppRole> roleManager, IMenuReadRepository menuReadRepository, IMenuWriteRepository menuWriteRepository, IEndpointReadRepository endpointReadRepository, IEndpointWriteRepository endpointWriteRepository)
        {
            _applicationService = applicationService;
            _roleManager = roleManager;
            _menuReadRepository = menuReadRepository;
            _menuWriteRepository = menuWriteRepository;
            _endpointReadRepository = endpointReadRepository;
            _endpointWriteRepository = endpointWriteRepository;
        }
        public async Task AssignRoleEndipointAsync(string role,int id)
        {
            
        }
        public async Task AssignRoleEndipointAsync(string roles,string menu, string code,Type type)
		{
            Menu _menu = await _menuReadRepository.GetSingleAsync(m => m.Name == menu);
            if (_menu == null)
            {
                _menu = new()
                {
                    Name = menu,
                    Status = true
                };
                await _menuWriteRepository.AddAsync(_menu);
                await _endpointWriteRepository.SaveAsync();
            }
            Endpoint? endpoint = await _endpointReadRepository.Table.Include(e => e.Menu)
                .Include(e => e.Roles)
                .FirstOrDefaultAsync(e => e.Code == code && e.Menu.Name == menu);
            if (endpoint == null)
            {
                var action = _menuReadRepository.GetAll()
                    .FirstOrDefault(m => m.Name == menu)
                    ?.Endpoints.FirstOrDefault(e => e.Code == code);
                endpoint = new()
                {
                    Code = action.Code,
                    ActionType = action.ActionType,
                    HttpType = action.HttpType,
                    Definition = action.Definition,
                    Menu = _menu
                };
                await _endpointWriteRepository.AddAsync(endpoint);
                await _endpointWriteRepository.SaveAsync();
            }
            foreach (var role in endpoint.Roles)
            {
                endpoint.Roles.Remove(role);
            }
            var appRoles = _roleManager.Roles.Where(r => roles.Contains(r.Name)).ToList();
            foreach (var role in appRoles)
            {
                endpoint.Roles.Add(role);
            }
            await _endpointWriteRepository.SaveAsync();

        }
	}
}
