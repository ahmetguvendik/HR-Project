using System;
using Application.Repositories;
using MediatR;

namespace Application.CQRS.Commands.Job.CreateJob
{
	public class CreateJobCommandHandler : IRequestHandler<CreateJobCommandRequest,CreateJobCommandResponse>
	{
        private readonly IJobWriteRepository _jobWriteRepository;
		public CreateJobCommandHandler(IJobWriteRepository jobWriteRepository)
		{
            _jobWriteRepository = jobWriteRepository;
		}

        public async Task<CreateJobCommandResponse> Handle(CreateJobCommandRequest request, CancellationToken cancellationToken)
        {
            var job = new Domain.Entities.Job();
            job.Id = Guid.NewGuid().ToString();
            job.JobName = request.JobName;
            job.Level = request.Level;
            job.Type = request.Type;
            job.Description = request.Description;
            job.CategoryId = request.CategoryId;
            await _jobWriteRepository.AddAsync(job);
            await _jobWriteRepository.SaveAsync();
            return new CreateJobCommandResponse()
            {
                CategoryId = request.CategoryId,
                Description = request.Description,
                JobName = request.JobName,
                Level = request.Level,
                Type = request.Type
            };
            
        }
    }
}

