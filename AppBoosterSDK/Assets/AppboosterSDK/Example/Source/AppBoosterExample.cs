using System;
using AppboosterSDK;
using AppboosterSDK.Types;
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
		AppBooster.Initialize(_sdkToken, _appId, null, null, true,
			true, new ExperimentValue("buttonColor", "blue"));

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
