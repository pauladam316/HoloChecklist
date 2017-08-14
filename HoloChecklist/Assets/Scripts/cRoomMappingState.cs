using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR.WSA;
using UnityEngine.VR.WSA.Input;

public class cRoomMappingState: IApplicationState
{
	public string[] UI_STRINGS =
	{
		"Look around to map the room\n Tap to continue"								//UI Elements to be shown on screen during room mapping
	};

	private cUIManager mUIManager;													//Reference to the UI manager
	private GestureRecognizer gestureRecognizer;									//Used for recognizing hololens air tap
	private cApplicationManager mApplicationManager;								//Reference to the application manager

	private SpatialMappingRenderer mRenderer;										//Reference to the spatial mappers
	private SpatialMappingCollider mCollider;

	public void Begin()
	{
		mApplicationManager = GameObject.FindObjectOfType<cApplicationManager>();	//Get the manager
		if (mRenderer == null)
		{
			mRenderer = GameObject.FindObjectOfType<SpatialMappingRenderer>();				
		}
		if (mCollider == null)
		{
			mCollider = GameObject.FindObjectOfType<SpatialMappingCollider>();
		}

		mRenderer.enabled = true;										//Default to active and unfrozen
		mRenderer.freezeUpdates = false;
		mCollider.enabled = true;
		mCollider.freezeUpdates = false;

		mUIManager = GameObject.FindObjectOfType<cUIManager>();						//Get the UI Manager
		mUIManager.UpdateUI(UI_STRINGS[0]);											//Set the UI text to the first string

		gestureRecognizer = new GestureRecognizer();								//Setup Gesture Recognizer
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
		mCollider.freezeUpdates = true;												//When the user taps, hide and freeze the spatial map, move on to the list placing
		mRenderer.freezeUpdates = true;
		mRenderer.enabled = false;
		mApplicationManager.ChangeState(new cItemPlacingState());
	}
}
