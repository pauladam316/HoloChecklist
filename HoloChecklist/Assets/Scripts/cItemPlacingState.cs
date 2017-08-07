using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cItemPlacingState : MonoBehaviour, IApplicationState
{
	public const string ICON_NAME = "Placement Icon";								//The name of the icon prefab
	public const string COLLIDER_PARENT_NAME = "Spatial Mapping Collider";			//Surface parent of the spatial mapping collider

	private GameObject mIcon;														//The icon used to place the checklist

	public void Begin()
	{
		//mIcon = new GameObject();
		mIcon = Instantiate(Resources.Load(ICON_NAME) as GameObject, Vector3.zero, Quaternion.identity);	//create the icon
	}

	public void Stop()
	{
		Destroy(mIcon);
	}

	void IApplicationState.Update()
	{
	
	}

	/**
	 * GetGazePosition
	 * Casts a ray from the camera, moving forward, finds the position on the spatial mapper that it hits
	 * @return the position on the collider
	 */
	public Vector3 GetGazePosition()
	{
		RaycastHit[] hits;
		hits = Physics.RaycastAll(Camera.main.transform.position, Camera.main.transform.forward);

		foreach(RaycastHit hit in hits)
		{
			if (hit.transform.parent.name == COLLIDER_PARENT_NAME)						//if the raycast name is equal to the surface parent.
			{
				return hit.point;
			}
		}
		return Vector3.zero;
	}

}
