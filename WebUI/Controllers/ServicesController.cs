using Application.Services.Commands.CreateService;
using Application.Services.Commands.DeleteService;
using Application.Services.Queries;
using Domain.DTOs;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    [Route("api/service")]
    public class ServicesController : ApiControllerBase
    {


        //GET ALL
        [HttpPost("getList")]
        public async Task<List<ServiceDTO>> GetList(GetServiceListQuery query)
        {
            return await Mediator.Send(query);
        }

        //GET BY ID
        [HttpGet("{id}")]
        public async Task<Service> GetServiceById(int id)
        {
            return await Mediator.Send(new GetServiceByIdQuery { Id = id });
        }

        //POST NEW SERVICE
        [HttpPost("create")]
        public async Task<int> CreateService(CreateServiceCommand command)
        {
            return await Mediator.Send(command);
        }

        //DELETE SERVICE
        [HttpDelete("delete/{id}")]
        public async Task<Unit> DeleteService(int id)
        {
            return await Mediator.Send(new DeleteServiceCommand { Id = id });
        }

        //UPDATE SERVICE
        [HttpPut("update")]
        public async Task<int> UpdateService(UpdateServiceCommand command)
        {
            return await Mediator.Send(command);
        }

        //GET SERVICE EMPLOYEES
        [HttpGet("service-employees/{id}")]
        public async Task<List<Employee>> GetServiceEmployees(int id)
        {
            return await Mediator.Send(new GetEmployeeServicesQuery { Id = id });
        }
    }
}
