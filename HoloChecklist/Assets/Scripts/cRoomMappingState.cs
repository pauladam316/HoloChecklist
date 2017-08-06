using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cRoomMappingState :  MonoBehaviour, IApplicationState
{
	public string[] UI_STRINGS =
	{
		"Look around to map the room\n Tap to continue"
	};

	private cUIManager mUIManager;

	public void Begin()
	{
		mUIManager = GameObject.FindObjectOfType<cUIManager>();
		mUIManager.UpdateUI(UI_STRINGS[0]);
	}

	public void Stop()
	{
		mUIManager.UpdateUI("");
	}

	void IApplicationState.Update()
	{

	}
}
