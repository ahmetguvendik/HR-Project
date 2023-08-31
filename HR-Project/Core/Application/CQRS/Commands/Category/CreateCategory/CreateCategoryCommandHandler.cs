using System;
using Application.Repositories;
using MediatR;

namespace Application.CQRS.Commands.Category.CreateCategory
{
	public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest,CreateCategoryCommandResponse>
	{
        private readonly ICategoryWriteRepository _categoryWriteRepository;
		public CreateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository)
		{
            _categoryWriteRepository = categoryWriteRepository;
		}

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = new Domain.Entities.Category();
            category.Id = Guid.NewGuid().ToString();
            category.CategoryName = request.CategoryName;
            await _categoryWriteRepository.AddAsync(category);
            await _categoryWriteRepository.SaveAsync();
            return new CreateCategoryCommandResponse()
            {
                CategoryName = request.CategoryName
            };
        }
    }
}

