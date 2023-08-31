using System;
namespace Application.CQRS.Commands.Job.CreateJob
{
	public class CreateJobCommandResponse
	{
        public string JobName { get; set; }
        public string Type { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
    }
}

