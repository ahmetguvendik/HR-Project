using System;
namespace Application.Exceptions
{
	public class NotFoundUserException : Exception
	{
		public NotFoundUserException() : base("Kullanıcı adı veya şifre hatalı.")
        {
		}
	}
}

