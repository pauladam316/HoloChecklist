using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cApplicationManager: MonoBehaviour {

	public IApplicationState CurrentState;

	/**
	 * ChangeState
	 * Changes the application state
	 * @param state - the new state to change to
	 */
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
