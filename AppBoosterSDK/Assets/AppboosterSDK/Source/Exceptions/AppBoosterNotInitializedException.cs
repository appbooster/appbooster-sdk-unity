using System;

namespace AppboosterSDK.Exceptions
{
	public class AppBoosterNotInitializedException: Exception
	{
		public AppBoosterNotInitializedException(): base("You must call AppBooster.Initialize() first!")
		{
		}
	}
}