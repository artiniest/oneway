using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour 
{
	public int levelToLoad = 0;

	void Update () 
	{
		if (Input.GetKey (KeyCode.Space)) 
		{
			Application.LoadLevel (levelToLoad);
		}
	}
}
