using System;
using Application.Repositories;
using MediatR;

namespace Application.CQRS.Queries.Job.GetByIdJob
{
	public class GetByIdJobQueryHandler : IRequestHandler<GetByIdJobQueryRequest,Domain.Entities.Job>
	{
        private readonly IJobReadRepository _jobReadRepository;
		public GetByIdJobQueryHandler(IJobReadRepository jobReadRepository)
		{
            _jobReadRepository = jobReadRepository;
		}

        public Task<Domain.Entities.Job> Handle(GetByIdJobQueryRequest request, CancellationToken cancellationToken)
        {
            var value = _jobReadRepository.GetById(request.Id);
            return value;
        }
    }
}

