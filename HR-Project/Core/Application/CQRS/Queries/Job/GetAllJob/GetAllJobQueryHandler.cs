using System;
using Application.Repositories;
using MediatR;

namespace Application.CQRS.Queries.Job.GetAllJob
{
	public class GetAllJobQueryHandler : IRequestHandler<GetAllJobQueryRequest,IQueryable<Domain.Entities.Job>>
	{
        private readonly IJobReadRepository _jobReadRepository;
		public GetAllJobQueryHandler(IJobReadRepository jobReadRepository)
		{
            _jobReadRepository = jobReadRepository;
		}

        public async Task<IQueryable<Domain.Entities.Job>> Handle(GetAllJobQueryRequest request, CancellationToken cancellationToken)
        {
            var values = _jobReadRepository.GetAll();
            return values;
        }
    }
}

