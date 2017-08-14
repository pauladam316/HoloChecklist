using System.Windows.Storage.Pickers;
using System.Windows.Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR.WSA.Input;


public class cItemPlacingState : MonoBehaviour, IApplicationState
{
	public const string ICON_NAME = "ChecklistPrefab";								//The name of the icon prefab
	public const string COLLIDER_PARENT_NAME = "Spatial Mapping Collider";          //Surface parent of the spatial mapping collider

	private GestureRecognizer gestureRecognizer;                                    //Used for recognizing hololens air tap
	private GameObject mIcon;														//The icon used to place the checklist

	public void Begin()
	{
		mIcon = Instantiate(Resources.Load(ICON_NAME) as GameObject, Vector3.zero, Quaternion.identity);    //create the icon

		gestureRecognizer = new GestureRecognizer();                                //Setup Gesture Recognizer
		gestureRecognizer.SetRecognizableGestures(GestureSettings.Tap);
		gestureRecognizer.TappedEvent += GestureRecognizer_TappedEvent;
		gestureRecognizer.StartCapturingGestures();

	}

	public void Stop()
	{
		Destroy(mIcon);
	}

	void IApplicationState.Update()
	{
		RaycastHit colliderHit = GetGazeHit();
		mIcon.transform.position = Vector3.MoveTowards(mIcon.transform.position, colliderHit.point, 0.5f);
		Quaternion rotation = Quaternion.RotateTowards(mIcon.transform.rotation, Quaternion.LookRotation(colliderHit.normal), 30f);

		mIcon.transform.LookAt(Camera.main.transform.position);
		mIcon.transform.eulerAngles = new Vector3(rotation.eulerAngles.x, mIcon.transform.eulerAngles.y, rotation.eulerAngles.z);
	}

	/**
	 * GetGazePosition
	 * Casts a ray from the camera, moving forward, finds the position on the spatial mapper that it hits
	 * @return the position on the collider
	 */
	public RaycastHit GetGazeHit()
	{
		RaycastHit[] hits;
		hits = Physics.RaycastAll(Camera.main.transform.position, Camera.main.transform.forward);

		foreach(RaycastHit hit in hits)
		{
			if (hit.transform.parent.name == COLLIDER_PARENT_NAME)						//if the raycast name is equal to the surface parent.
			{
				return hit;
			}
		}
		return new RaycastHit();
	}

	private void GestureRecognizer_TappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
	{
		//FileOpenPicker openPicker = new FileOpenPicker();
	}

}
