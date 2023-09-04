using System;
using Application.Repositories;
using MediatR;

namespace Application.CQRS.Commands.Job.UpdateJob
{
	public class UpdateJobCommandHandler : IRequestHandler<UpdateJobCommandRequest,UpdateJobCommandResponse>
	{
        private readonly IJobReadRepository _jobReadRepository;
        private readonly IJobWriteRepository _jobWriteRepository;
		public UpdateJobCommandHandler(IJobWriteRepository jobWriteRepository,IJobReadRepository jobReadRepository)
		{
            _jobReadRepository = jobReadRepository;
            _jobWriteRepository = jobWriteRepository;
		}

        public async Task<UpdateJobCommandResponse> Handle(UpdateJobCommandRequest request, CancellationToken cancellationToken)
        {
            var job = await _jobReadRepository.GetById(request.Id);
            job.JobName = request.JobName;
            job.Level = request.Level;
            job.Description = request.Description;
            job.CategoryId = request.CategoryId;
            job.Type = request.Type;
            await _jobWriteRepository.SaveAsync();
            return new UpdateJobCommandResponse()
            {
                CategoryId = request.CategoryId,
                Description = request.Description,
                Id = request.Id,
                JobName = request.JobName,
                Type = request.Type,
                Level = request.Level
            };
            
        }
    }
}

