using System;
namespace Application.CQRS.Commands.Employee.CreateEmployee
{
	public class CreateEmployeeCommandResponse
	{
        public string Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string JobId { get; set; }
        public string UserId { get; set; }
    }

}

