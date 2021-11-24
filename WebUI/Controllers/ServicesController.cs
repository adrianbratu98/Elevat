﻿using Application.Services.Commands.CreateService;
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
        public async Task<Service> Get(int id)
        {
            return await Mediator.Send(new GetServiceByIdQuery { Id = id });
        }

        //POST NEW SERVICE
        [HttpPost("create")]
        public async Task<int> Create(CreateServiceCommand command)
        {
            return await Mediator.Send(command);
        }

        //DELETE SERVICE
        [HttpDelete("delete/{id}")]
        public async Task<Unit> Delete(int id)
        {
            return await Mediator.Send(new DeleteServiceCommand { Id = id });
        }

        //UPDATE SERVICE
        [HttpPut("update")]
        public async Task<int> Update(UpdateServiceCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
