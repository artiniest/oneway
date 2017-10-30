using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
	//Älä koske tämän yläpuolelle mihinkään!!!

	public GameObject[] tracks; //Luodaan GameObject-lista, johon lisätään Inspectorista "radat"
	public int currentTrack; //0 = kaukainen oikea, 1 = oikea, 2 = keskimmäinen, 3 = vasen, 4 = kaukainen vasen

	void Start ()
	{
		currentTrack = 2; //Aloituspiste, keskellä
	}

	void Update ()
	{
		switch (currentTrack) //Switch case liikkumiselle. Älkää koskeko ilman valvojaa! :D
		{
		case -1:
			currentTrack = 0;
			break;
		case 0:
			transform.position = new Vector2 (tracks [currentTrack].transform.position.x, transform.position.y);
			break;
		case 1:
			transform.position = new Vector2 (tracks [currentTrack].transform.position.x, transform.position.y);
			break;
		case 2:
			transform.position = new Vector2 (tracks [currentTrack].transform.position.x, transform.position.y);
			break;
		case 3:
			transform.position = new Vector2 (tracks [currentTrack].transform.position.x, transform.position.y);
			break;
		case 4:
			transform.position = new Vector2 (tracks [currentTrack].transform.position.x, transform.position.y);
			break;
		case 5:
			currentTrack = 4;
			break;
		}

		if (Input.GetKeyDown (KeyCode.RightArrow)) //Kun painetaan oikealle-nuolta..
		{
			currentTrack --; //Siirry oikealle
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow)) //Kun painetaan vasemmalle-nuolta..
		{
			currentTrack ++; //Siirry vasemmalle
		}
	}

	void OnTriggerEnter(Collider other) //Kun triggeröidytään..
	{
		transform.Translate (new Vector2 (transform.position.x, +1)); //Siirretään pelaajaa yksi yksikkö ylemmäs = lähemmäs lonkeroita
		Destroy (other.GetComponent<Collider>()); //Tuhotaan esteen collider, ettei tule ongelmia :)
	}
}
