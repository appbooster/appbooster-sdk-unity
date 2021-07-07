using System;
using AppboosterSDK;
using UnityEngine;
using UnityEngine.UI;

// ReSharper disable once CheckNamespace
public class AppBoosterExample : MonoBehaviour
{
	[SerializeField] private string _sdkToken = "Insert you SDK token here!";
	[SerializeField] private string _appId = "Insert you AppId here!";

	[Space, SerializeField] private Button _button;

	void Start()
	{
		AppBooster.Initialize(sdkToken: _sdkToken,
			appId: _appId,
			usingShake: true,
			debugLogs: true,
			defaults: new[]
			{
				("buttonColor", "blue")
			},
			deviceProperties: new[]
			{
				("installedAt", DateTime.Now.ToString()),
			}
			);

		if (AppBooster.HasValue("buttonColor"))
		{
			_button.GetComponentInChildren<Text>().text = AppBooster.GetValue("buttonColor");
		}

		FetchData();
	}

	public void OnButtonClick()
	{
		AppBooster.LaunchDebugMode();
	}

	private async void FetchData()
	{
		try
		{
			await AppBooster.FetchAsync();

			if (AppBooster.HasValue("buttonColor"))
			{
				_button.GetComponentInChildren<Text>().text = AppBooster.GetValue("buttonColor");
			}
		}
		catch (Exception e)
		{
			Debug.LogError($"Error initializing AppBooster: {e}");
		}
	}
}