using System;
using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class cChecklistButton: MonoBehaviour
{
	private GestureRecognizer gestureRecognizer;                                    //Used for recognizing hololens air tap
	private Color mNormalColor = Color.white;										//unhighlighted color
	private Color mHighlightedColor = new Color(0.380f, 0.380f, 0.380f);
	public event EventHandler OnPropertyChanged;									//handle button presses

	public bool Highlighted = false;

	private void Start()
	{
		gestureRecognizer = new GestureRecognizer();                                //Setup Gesture Recognizer
		gestureRecognizer.SetRecognizableGestures(GestureSettings.Tap);
		gestureRecognizer.TappedEvent += GestureRecognizer_TappedEvent;
		gestureRecognizer.StartCapturingGestures();
	}

	private void Update()
	{
		if (!Highlighted && LookingAtButton())										//highlight if we are looking at it
		{
			HighlightButton();
		}
		else if (Highlighted && !LookingAtButton())
		{
			UnhighlightButton();													//otherwise dont
		}
	}

	private void GestureRecognizer_TappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
	{	
		if (Highlighted)
		{
			OnPropertyChanged(this, new EventArgs());
		}
	}

	/**
	 * HighlightButton
	 * Changes the color to the selected color
	 */
	public void HighlightButton()
	{
		Highlighted = true;
		GetComponent<Renderer>().material.SetColor("_Tint", mHighlightedColor);
	}

	/**
	 * UnhighlightButton
	 * Changes the color to the unselected color
	 */
	public void UnhighlightButton()
	{
		Highlighted = false;
		GetComponent<Renderer>().material.SetColor("_Tint", mNormalColor);
	}

	/**
	 * LookingAtButton
	 * Checks to see if the camera transform is looking at the button specified
	 * @return if it is looking at the button
	 */
	private bool LookingAtButton()
	{
		RaycastHit[] hits;

		hits = Physics.RaycastAll(Camera.main.transform.position, Camera.main.transform.forward);

		foreach (RaycastHit hit in hits)
		{
			if (hit.transform.gameObject == this.gameObject)
			{
				return true;
			}
		}
		return false;
	}
}