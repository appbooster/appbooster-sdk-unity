using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AppboosterSDK.Exceptions;
using AppboosterSDK.Internal;
using AppboosterSDK.Types;

namespace AppboosterSDK
{
	public static class AppBooster
	{
		private static AppBoosterManager _manager; 
		
		public static void Initialize(string sdkToken, string appId, string deviceId = null, string appsFlyerId = null, bool usingShake = true,
			bool debugLogs = false, params ExperimentValue[] defaults)
		{
			_manager = new AppBoosterManager(sdkToken, appId, deviceId, appsFlyerId, usingShake, debugLogs, defaults);
		}

		public static Task FetchAsync(CancellationToken ct = default)
		{
			if (_manager == null)
			{
				throw new AppBoosterNotInitializedException();
			}
			
			return _manager.FetchAsync(ct);
		}

		public static void LaunchDebugMode()
		{
			if (_manager == null)
			{
				throw new AppBoosterNotInitializedException();
			}

			_manager.OpenDebugView();
		}

		public static bool HasValue(string key)
		{
			if (_manager == null)
			{
				throw new AppBoosterNotInitializedException();
			}

			return _manager.HasValue(key);
		}

		public static string GetValue(string key)
		{
			if (_manager == null)
			{
				throw new AppBoosterNotInitializedException();
			}

			return _manager.GetValue(key);
		}
		
		public static IReadOnlyDictionary<string, string> GetExperiments()
		{
			if (_manager == null)
			{
				throw new AppBoosterNotInitializedException();
			}

			return _manager.GetExperiments();
		}
		
		public static IReadOnlyDictionary<string, string> GetExperimentsWithDetails()
		{
			if (_manager == null)
			{
				throw new AppBoosterNotInitializedException();
			}

			return _manager.GetExperimentsWithDetails();
		}
	}
}