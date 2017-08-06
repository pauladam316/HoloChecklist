using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cApplicationManager: MonoBehaviour {

	public IApplicationState CurrentState;

	public cRoomMappingState RoomMappingState;
	public cItemPlacingState ItemPlacingState;

	public void ChangeState(IApplicationState state)
	{
		CurrentState.Stop();
		CurrentState = state;
		state.Begin();
	}

	private void Start()
	{
		CurrentState = new cRoomMappingState();
		CurrentState.Begin();	
	}

	private void Update()
	{
		CurrentState.Update();
	}
}
