using System;
namespace Domain.Entities
{
	public class Job : BaseEntity
	{
		public string JobName { get; set; }
		public string Type { get; set; }
		public int Level { get; set; }
		public string Description { get; set; }	
		public Category Category { get; set; }
		public string CategoryId { get; set; }
        public IQueryable<Employee> Employees { get; set; }

    }
}

