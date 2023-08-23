using System;
using MediatR;

namespace Application.CQRS.Commands.Employee.CreateEmployee
{
	public class CreateEmployeeCommandRequest : IRequest<CreateEmployeeCommandResponse>
	{
		public string Name { get; set; }
		public string SurName { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string JobId { get; set; }	
	}
}

