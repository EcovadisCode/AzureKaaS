using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting.Client;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController()
        {
            _projectService = ServiceProxy.Create<IProjectService>(new Uri("fabric:/KaasDemo/ProjectService"), new ServicePartitionKey(922337203685477580));
        }

        public async Task<string> Get()
        {
            return await _projectService.GetProductName();
        }

        [HttpGet("{id}")]
        public async Task<string> GetById(int id)
        {
            return await _projectService.GetProductNameById(id);
        }

        [HttpPut("{id}")]
        public async Task AddNewProject(int id, [FromBody]string name)
        {
            await _projectService.AddProduct(id, name);
        }
    }
}