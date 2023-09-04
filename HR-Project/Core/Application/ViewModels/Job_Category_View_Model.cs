using System;
using Domain.Entities;

namespace Application.ViewModels
{
	public class Job_Category_View_Model
	{
        public string JobId { get; set; }        
        public string JobName { get; set; }
        public string Type { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }    
    }
}

