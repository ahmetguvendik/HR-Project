using System;
using Application.Repositories;
using MediatR;

namespace Application.CQRS.Commands.Employee.CreateEmployee
{
	public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommandRequest,CreateEmployeeCommandResponse>
	{
        private readonly IEmployeeWriteRepository _employeeWriteRepository;
        private readonly IJobReadRepository _jobReadRepository;
		public CreateEmployeeCommandHandler(IEmployeeWriteRepository employeeWriteRepository,IJobReadRepository jobReadRepository)
		{
            _employeeWriteRepository = employeeWriteRepository;
            _jobReadRepository = jobReadRepository;
		}

        public async Task<CreateEmployeeCommandResponse> Handle(CreateEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            var employee = new Domain.Entities.Employee();
            employee.Id = Guid.NewGuid().ToString();
            employee.Name = request.Name;
            employee.Surname = request.SurName;
            employee.Title = request.Title;
            var job = await _jobReadRepository.GetById(request.JobId);
            employee.jobs = new List<Domain.Entities.Job>()
            {
                new()
                {
                    JobName = job.JobName,
                    Category = job.Category,
                    Description = job.Description,
                    Level = job.Level,
                    Type = job.Type
                   
                }
            };
            employee.Description = request.Description;
            await _employeeWriteRepository.AddAsync(employee);
            await _employeeWriteRepository.SaveAsync();
            return new CreateEmployeeCommandResponse()
            {
                Name = request.Name,
                SurName = request.SurName,
                Description = request.Description,
                Title = request.Title,
                JobId = request.JobId
            };
        }
    }
}

