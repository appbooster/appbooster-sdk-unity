using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace AppboosterSDK.Internal
{
	internal static class AsyncWebHelper
	{
		public static async Task<string> MakeApiRequestAsync(string apiUrl, string queryArgs, CredentialsData credentials, CancellationToken ct)
		{
			var url = $"{Constants.ApiHost}/{Constants.MobileApiPath}/{apiUrl}";

			if (!string.IsNullOrEmpty(queryArgs))
			{
				url += $"?{queryArgs}";
			}

			using (var request = new UnityWebRequest(url, "GET", new DownloadHandlerBuffer(), null))
			{
				request.SetRequestHeader(Constants.HeaderContent, Constants.HeaderContentValue);
				request.SetRequestHeader(Constants.HeaderAppVersion, Constants.HeaderAppVersionValue);
				request.SetRequestHeader(Constants.HeaderAppId, credentials.AppId);
				request.SetRequestHeader(Constants.HeaderAuth, $"Bearer {credentials.AuthToken}");
				request.timeout = Constants.RequestTimeoutSec;

				var op = request.SendWebRequest();
				while (!op.isDone)
				{
					await Task.Delay(100, ct);
				}

				if (request.isNetworkError)
				{
					throw new Exception($"Network error while sending request '{url}': {request.error}");
				}

				if (request.isHttpError)
				{
					throw new Exception($"Http error while sending request '{url}': {request.error}");
				}

				return request.downloadHandler.text;
			}
		}
	}
}