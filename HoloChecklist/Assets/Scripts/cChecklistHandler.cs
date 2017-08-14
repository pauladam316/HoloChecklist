using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cChecklistHandler : MonoBehaviour {

	public cChecklistButton ExpandButton;
	public cChecklistButton MinimizeButton;
	public cChecklistButton TakePhotoButton;

	public GameObject MaximizedElement;
	public GameObject ActiveItem;

	// Use this for initialization
	void Start () {
		ExpandButton.OnPropertyChanged += ExpandButton_OnPropertyChanged;
		MinimizeButton.OnPropertyChanged += MinimizeButton_OnPropertyChanged;
	}

	private void MinimizeButton_OnPropertyChanged(object sender, EventArgs e)
	{
		UnhighlightAll();
		MaximizedElement.SetActive(false);
		ActiveItem.SetActive(true);
	}

	private void ExpandButton_OnPropertyChanged(object sender, EventArgs e)
	{
		UnhighlightAll();
		MaximizedElement.SetActive(true);
		ActiveItem.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
		
	}

	void UnhighlightAll()
	{
		ExpandButton.UnhighlightButton();
		MinimizeButton.UnhighlightButton();
		TakePhotoButton.UnhighlightButton();
	}
}
