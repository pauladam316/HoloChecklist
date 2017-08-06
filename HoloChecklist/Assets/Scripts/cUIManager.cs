using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cUIManager : MonoBehaviour {

	public TextMesh Text;

	public void UpdateUI(string text)
	{
		Text.text = text;
	}

	private void Update()
	{
		transform.LookAt(Camera.main.transform);
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);
	}
}
