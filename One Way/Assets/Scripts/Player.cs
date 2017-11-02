using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
    //Älä koske tämän yläpuolelle mihinkään!!!

	public Animation sproot;
    public GameObject face; //Naaama
	public GameObject[] tracks; //Luodaan GameObject-lista, johon lisätään Inspectorista "radat"
	public GameObject kamera;
	public int currentTrack; //0 = kaukainen oikea, 1 = oikea, 2 = keskimmäinen, 3 = vasen, 4 = kaukainen vasen
    public AudioSource source;

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
            GetComponent<Animator>().SetTrigger("Roll");
			currentTrack --; //Siirry oikealle
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow)) //Kun painetaan vasemmalle-nuolta..
		{
            GetComponent<Animator>().SetTrigger("Roll2");
			currentTrack ++; //Siirry vasemmalle
		}
	}

	void OnTriggerEnter2D(Collider2D other) //Kun triggeröidytään..
	{
		switch (other.gameObject.tag) 
		{
		case "Obstacle":
			face.SetActive(true);
			//source.Play();
			transform.Translate(new Vector2(transform.position.x, +2)); //Siirretään pelaajaa yksi yksikkö ylemmäs = lähemmäs lonkeroita
			kamera.transform.Translate(new Vector2(kamera.transform.position.x, +2)); //Siirretään kameraa myös ylöspäin
			break;
		case "Kuppi":
			GetComponent<Animator> ().SetTrigger ("Kuppi");
			transform.Translate(new Vector2(transform.position.x, -6)); //Siirretään pelaajaa yksi yksikkö alemmas = kauemmas lonkeroista
			kamera.transform.Translate(new Vector2(kamera.transform.position.x, -6)); //Siirretään kameraa myös alaspäin
			Destroy(other.gameObject); //Tuhotaan poweruppi
			break;
		case "Piippu":
			GetComponent<Animator> ().SetTrigger ("Piippu");
			transform.Translate(new Vector2(transform.position.x, -6)); //Siirretään pelaajaa yksi yksikkö alemmas = kauemmas lonkeroista
			kamera.transform.Translate(new Vector2(kamera.transform.position.x, -6)); //Siirretään kameraa myös alaspäin
			Destroy(other.gameObject); //Tuhotaan poweruppi
			break;
		case "Darkness":
			sproot.Play ();
			Invoke ("Death", 2);
			break;
		}
	}

	void Death ()
	{
		Application.LoadLevel(1); //Ladataan gameOver-scene.
	}

    void OnTriggerExit2D (Collider2D other)
    {
        face.SetActive(false);
    }
}
