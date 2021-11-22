using Application.Employees.Queries;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace WebUI.Controllers
{
    [Route("api/employee")]
    public class EmployeesController : ApiControllerBase
    {


        //GET ALL
        [HttpGet("all")]
        public async Task<List<Employee>> GetServiceList()
        {
            return await Mediator.Send(new GetEmployeesListQuery());
        }

        //GET SERVICE EMPLOYEES
        [HttpGet("employee-services/{id}")]
        public async Task<List<Service>> GetEmployeeServices(int id)
        {
            return await Mediator.Send(new GetEmployeeServicesQuery { Id = id });
        }
    }
}
