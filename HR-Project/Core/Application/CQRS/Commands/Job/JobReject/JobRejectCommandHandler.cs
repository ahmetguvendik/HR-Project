using System;
using Application.Repositories;
using MediatR;

namespace Application.CQRS.Commands.Job.JobReject
{
	public class JobRejectCommandHandler : IRequestHandler<JobRejectCommandRequest,JobRejectCommandResponse>
	{
        private readonly IEmployeeJobReadRepository _employeeJobReadRepository;
        private readonly IEmployeeJobWriteRepository _employeeJobWriteRepository;
        public JobRejectCommandHandler(IEmployeeJobReadRepository employeeJobReadRepository, IEmployeeJobWriteRepository employeeJobWriteRepository)
		{
            _employeeJobReadRepository = employeeJobReadRepository;
            _employeeJobWriteRepository = employeeJobWriteRepository;
		}

        public async Task<JobRejectCommandResponse> Handle(JobRejectCommandRequest request, CancellationToken cancellationToken)
        {
            var employeeJob = await _employeeJobReadRepository.GetById(request.Id);
            employeeJob.IsRed = true;
            await _employeeJobWriteRepository.SaveAsync();
            return new JobRejectCommandResponse();
        }
    }
}

