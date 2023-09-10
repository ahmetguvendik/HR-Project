using System;
namespace Domain.Entities
{
	public class Employee : BaseEntity
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public IQueryable<Job> Jobs { get; set; }
		public AppUser User { get; set; }
		public string UserId { get; set; }	

	}
}

