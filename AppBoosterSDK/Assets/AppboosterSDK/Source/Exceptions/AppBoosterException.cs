using System;

namespace AppboosterSDK.Exceptions
{
	public class AppBoosterException: Exception
	{
		public AppBoosterException()
		{
		}

		public AppBoosterException(string message) : base(message)
		{
		}

		public AppBoosterException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}