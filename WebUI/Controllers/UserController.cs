using Application.Employees.Commands.CreateEmployee;
using Application.Employees.Queries;
using Application.Users.Commands;
using Application.Users.Queries;
using Domain.Dtos;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebUI.Controllers
{
    [Route("api/user")]
    public class UserController : ApiControllerBase
    {

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterUserCommand command)
            => Ok(await Mediator.Send(command));


        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginUserCommand command)
        {
            var token = await Mediator.Send(command);
            return Ok(new { token });
        }
            

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<AccountDto>> Get()
        {
            var query = new UserAccountQuery();
            query.Id = Int32.Parse(User.Claims.First(c => c.Type == "UserID").Value);
            return Ok(await Mediator.Send(query));
        }


        [HttpPost("employee/create")]
        public async Task<ActionResult<int>> CreateEmployee(CreateEmployeeCommand command)
        {
            return Ok(await Mediator.Send(command));

        }


        [HttpGet("getList")]
        public async Task<ActionResult<List<Account>>> GetEmployees()
        {
            return Ok(await Mediator.Send(new GetEmployeeListQuery()));

        }
    }
}
