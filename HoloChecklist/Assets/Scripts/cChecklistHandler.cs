using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cChecklistHandler : MonoBehaviour {

	public cChecklistButton ExpandButton;
	

	// Use this for initialization
	void Start () {
		ExpandButton.OnPropertyChanged += ExpandButton_OnPropertyChanged;
	}

	private void ExpandButton_OnPropertyChanged(object sender, EventArgs e)
	{
		throw new NotImplementedException();
	}

	// Update is called once per frame
	void Update () {
		
	}

	private void ExpandButton_Click(object sender)
	{

	}
}
