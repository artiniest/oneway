using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour 
{
	public int levelToLoad = 0;
	public GameObject img;
	bool isEnabled = false;

	void Update () 
	{
		if (Input.GetKey (KeyCode.Space)) 
		{
			Application.LoadLevel (levelToLoad);
		}

		if (isEnabled == false && img != null) 
		{
			img.gameObject.SetActive (false);
		}

		if (isEnabled == true && img != null) 
		{
			img.gameObject.SetActive (true);
		}
	}

	public void OnClick ()
	{
		Application.LoadLevel (levelToLoad);
	}

	public void OnClick2 ()
	{
		isEnabled = true;
	}

	public void OnClick3()
	{
		isEnabled = false;
	}
}
