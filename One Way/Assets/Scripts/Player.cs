using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
	//Älä koske tämän yläpuolelle mihinkään!!!

	public GameObject[] tracks; //Luodaan GameObject-lista, johon lisätään Inspectorista "radat"
	int currentTrack; //0 = ylin, 1 = keskimmäinen, 2 = alin

	void Start ()
	{
		currentTrack = 1; //Aloituspiste. Voidaan vaihtaa myös 0 tai 2, jos välttämättä haluaa.
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.UpArrow)) //Kun painetaan ylös-nuolta..
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

		if (Input.GetKeyDown (KeyCode.DownArrow)) //Kun painetaan alas-nuolta..
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

		transform.position = new Vector2 (transform.position.x, tracks [currentTrack].transform.position.y); //Siirretään pelaaja currentTrack-arvon mukaiselle raiteelle.
	}
}
