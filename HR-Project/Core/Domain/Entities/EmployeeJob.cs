using System;
namespace Domain.Entities
{
	public class EmployeeJob : BaseEntity
	{
		public string EmployeeId { get; set; }
		public string JobId { get; set; }
		public Employee Employee { get; set; }
		public Job Job { get; set; }
		public bool IsOk { get; set; }
		public bool IsRed { get; set; }	
	}
}

