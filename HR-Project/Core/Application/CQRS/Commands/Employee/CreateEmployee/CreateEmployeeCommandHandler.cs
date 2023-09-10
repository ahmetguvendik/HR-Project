using System;
using System.Linq;
using Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Commands.Employee.CreateEmployee
{
	public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommandRequest,CreateEmployeeCommandResponse>
	{
        private readonly IEmployeeWriteRepository _employeeWriteRepository;
        private readonly IJobReadRepository _jobReadRepository;
        private readonly IEmployeeJobWriteRepository _employeeJobWriteRepository;
		public CreateEmployeeCommandHandler(IEmployeeWriteRepository employeeWriteRepository,IJobReadRepository jobReadRepository, IEmployeeJobWriteRepository employeeJobWriteRepository)
		{
            _employeeWriteRepository = employeeWriteRepository;
            _jobReadRepository = jobReadRepository;
            _employeeJobWriteRepository = employeeJobWriteRepository;
		}

        public async Task<CreateEmployeeCommandResponse> Handle(CreateEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            var employee = new Domain.Entities.Employee();
            employee.Id = Guid.NewGuid().ToString();
            employee.Name = request.Name;
            employee.Surname = request.SurName;
            employee.Title = request.Title;
            employee.Description = request.Description;
            var emplooyeeJob = new Domain.Entities.EmployeeJob();
            emplooyeeJob.Id = Guid.NewGuid().ToString();
            emplooyeeJob.EmployeeId = employee.Id;
            emplooyeeJob.JobId = request.JobId;
            employee.UserId = request.UserId;
            await _employeeJobWriteRepository.AddAsync(emplooyeeJob);
            await _employeeWriteRepository.AddAsync(employee);
            await _employeeWriteRepository.SaveAsync();
            return new CreateEmployeeCommandResponse()
            {
                Name = request.Name,
                SurName = request.SurName,
                Description = request.Description,
                Title = request.Title,
                JobId = request.JobId,
                UserId = request.UserId
            
            };
        }
    }
}

