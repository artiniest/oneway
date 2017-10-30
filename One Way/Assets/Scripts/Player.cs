using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
	//Älä koske tämän yläpuolelle mihinkään!!!

	public GameObject[] tracks; //Luodaan GameObject-lista, johon lisätään Inspectorista "radat"
	int currentTrack; //0 = oikea, 1 = keskimmäinen, 2 = vasen

	void Start ()
	{
		currentTrack = 1; //Aloituspiste. Voidaan vaihtaa myös 0 tai 2, jos välttämättä haluaa.
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.RightArrow)) //Kun painetaan oikealle-nuolta..
		{
			if (currentTrack == 1) //Jos olet tällä hetkellä 1 = keskimmäisellä raiteella...
			{
				currentTrack --; //Siirry oikealle
			}

			if (currentTrack == 2) //Jos olet tällä hetkellä 2 = vasemmalla raiteella
			{
				currentTrack --; //Siirry oikealle
			}
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow)) //Kun painetaan vasemmalle-nuolta..
		{
			if (currentTrack == 1) // Jos olet tällä hetkellä 1 = keskimmäisellä raiteella..
			{
				currentTrack ++; //Siirry vasemmalle
			}

			if (currentTrack == 0) //Jos olet tällä hetkellä 0 = ylimmällä raiteella..
			{
				currentTrack ++; //Siirry vasemmalle
			}
		}

		transform.position = new Vector2 (tracks [currentTrack].transform.position.x, transform.position.y); //Siirretään pelaaja currentTrack-arvon mukaiselle raiteelle.
	}
}
