using System;
using Application.Repositories;
using MediatR;

namespace Application.CQRS.Commands.Job.RemoveJob
{
	public class RemoveJobCommandHandler : IRequestHandler<RemoveJobCommandRequest,RemoveJobCommandResponse>
	{
        private readonly IJobWriteRepository _jobWriteRepository;
		public RemoveJobCommandHandler(IJobWriteRepository jobWriteRepository)
		{
            _jobWriteRepository = jobWriteRepository;
		}

        public async Task<RemoveJobCommandResponse> Handle(RemoveJobCommandRequest request, CancellationToken cancellationToken)
        {
            await _jobWriteRepository.RemoveAsync(request.Id);
            await _jobWriteRepository.SaveAsync();
            return new RemoveJobCommandResponse();
        }
    }
}

