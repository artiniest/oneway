using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
	public GameObject[] tracks;
	int currentTrack; //0 = ylin, 1 = keskimmäinen, 2 = alin

	void Start ()
	{
		currentTrack = 1;
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			if (currentTrack == 1) //Jos olet tällä hetkellä 1 = keskimmäisellä raiteella...
			{
				currentTrack --; //Siirry ylöspäin
			}

			if (currentTrack == 2) //Jos olet tällä hetkellä 2 = alimmalla raiteella
			{
				currentTrack --; //Siirry ylöspäin
			}
		}

		if (Input.GetKeyDown (KeyCode.DownArrow)) 
		{
			if (currentTrack == 1) // Jos olet tällä hetkellä 1 = keskimmäisellä raiteella..
			{
				currentTrack ++; //Siirry alaspäin
			}

			if (currentTrack == 0) //Jos olet tällä hetkellä 0 = ylimmällä raiteella..
			{
				currentTrack ++; //Siirry alaspäin
			}
		}

		transform.position = tracks [currentTrack].transform.position;
	}
}
