using System;
namespace Application.Services
{
	public interface IMailService
	{
        public Task SendEmailAsync(string emailAdress, string body);
    }
}

