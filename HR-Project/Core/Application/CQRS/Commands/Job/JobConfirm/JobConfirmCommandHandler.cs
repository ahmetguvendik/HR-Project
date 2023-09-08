using System;
using Application.Repositories;
using MediatR;

namespace Application.CQRS.Commands.Job.JobConfirm
{
	public class JobConfirmCommandHandler : IRequestHandler<JobConfirmCommandRequest,JobConfirmCommandResponse>
	{
		private readonly IEmployeeReadRepository _employeeReadRepository;
		private readonly IEmployeeJobReadRepository _employeeJobReadRepository;
        private readonly IEmployeeWriteRepository _employeeWriteRepository;
		public JobConfirmCommandHandler(IEmployeeReadRepository employeeReadRepository, IEmployeeWriteRepository employeeWriteRepository,IEmployeeJobReadRepository employeeJobReadRepository)
		{
			_employeeWriteRepository = employeeWriteRepository;
			_employeeReadRepository = employeeReadRepository;
			_employeeJobReadRepository = employeeJobReadRepository;

        }

        public async Task<JobConfirmCommandResponse> Handle(JobConfirmCommandRequest request, CancellationToken cancellationToken)
        {
			var employeeJob = await _employeeJobReadRepository.GetById(request.Id);
            employeeJob.IsOk = true;		
			await _employeeWriteRepository.SaveAsync();
			return new JobConfirmCommandResponse();
			
        }
    }
}

