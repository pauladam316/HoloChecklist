using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class cRoomMappingState :  MonoBehaviour, IApplicationState
{
	public string[] UI_STRINGS =
	{
		"Look around to map the room\n Tap to continue"
	};

	private cUIManager mUIManager;
	private GestureRecognizer gestureRecognizer;
	private cApplicationManager mApplicationManager;

	public void Begin()
	{
		mApplicationManager = GameObject.FindObjectOfType<cApplicationManager>();

		mUIManager = GameObject.FindObjectOfType<cUIManager>();
		mUIManager.UpdateUI(UI_STRINGS[0]);

		gestureRecognizer = new GestureRecognizer();
		gestureRecognizer.SetRecognizableGestures(GestureSettings.Tap);
		gestureRecognizer.TappedEvent += GestureRecognizer_TappedEvent;
		gestureRecognizer.StartCapturingGestures();

	}

	public void Stop()
	{
		mUIManager.UpdateUI("");
	}

	void IApplicationState.Update()
	{

	}

	private void GestureRecognizer_TappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
	{
		mApplicationManager.ChangeState(GameObject.FindObjectOfType<cItemPlacingState>());
	}
}
