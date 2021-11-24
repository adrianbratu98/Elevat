using Application.Employees.Commands.CreateEmployee;
using Application.Employees.Queries;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace WebUI.Controllers
{
    [Route("api/employee")]
    public class EmployeesController : ApiControllerBase
    {


        //GET ALL
        [HttpGet("getList")]
        public async Task<List<Employee>> GetList()
        {
            return await Mediator.Send(new GetEmployeesListQuery());
        }

        //POST NEW EMPLOYEE
        [HttpPost("create")]
        public async Task<int> Create(CreateEmployeeCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
