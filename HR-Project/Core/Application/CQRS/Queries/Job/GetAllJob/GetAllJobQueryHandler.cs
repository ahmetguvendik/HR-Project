using System;
using Application.Repositories;
using Application.Services;
using Application.ViewModels;
using MediatR;

namespace Application.CQRS.Queries.Job.GetAllJob
{
	public class GetAllJobQueryHandler : IRequestHandler<GetAllJobQueryRequest,IQueryable<Job_Category_View_Model>>
	{
        private readonly IJobReadRepository _jobReadRepository;
        private readonly IJobCategoryService _jobCategoryService;
		public GetAllJobQueryHandler(IJobReadRepository jobReadRepository,IJobCategoryService jobCategoryService)
		{
            _jobReadRepository = jobReadRepository;
            _jobCategoryService = jobCategoryService;
		}

        public async Task<IQueryable<Job_Category_View_Model>> Handle(GetAllJobQueryRequest request, CancellationToken cancellationToken)
        {
            var values = _jobCategoryService.GetJobCategory();
            return values;
        }
    }
}

