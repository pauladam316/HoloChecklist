using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cUIManager : MonoBehaviour {

	public TextMesh Text;

	public void UpdateUI(string text)
	{
		Text.text = text;
	}
}
