﻿using Application.Employees.Commands.CreateEmployee;
using Application.Employees.Queries;
using Application.Users.Commands;
using Application.Users.Queries;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            => Ok(await Mediator.Send(command));

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<AccountDto>> Get()
        {
            var query = new UserAccountQuery();
            query.Email = User.FindFirstValue(ClaimTypes.Email);
            return Ok(await Mediator.Send(query));
        }
    }
}
