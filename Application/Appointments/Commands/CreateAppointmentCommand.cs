using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Dtos;

namespace Application.Employees.Commands.CreateEmployee
{
    public class CreateAppointmentCommand : IRequest<int>
    {
        public AppointmentDto AppointmentDto { get; set; }
    }

    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, int>
    {
        private readonly IElevatDbContext _context;

        public CreateAppointmentCommandHandler(IElevatDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            return 0;  
            
        }
    }
}
