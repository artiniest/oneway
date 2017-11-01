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
        if (other.tag == "Obstacle") //Jos toisen objektin tagi on "Obstacle"...
        {
            face.SetActive(true);
            //source.Play();
            transform.Translate(new Vector2(transform.position.x, +2)); //Siirretään pelaajaa yksi yksikkö ylemmäs = lähemmäs lonkeroita
            kamera.transform.Translate(new Vector2(kamera.transform.position.x, +2)); //Siirretään kameraa myös ylöspäin
            //Destroy(other.GetComponent<Collider2D>()); //Tuhotaan esteen collider, ettei tule ongelmia :)
        }

        if (other.tag == "Powerup") //Jos toisen objektin tagi on "Powerup"
        {
            transform.Translate(new Vector2(transform.position.x, -6)); //Siirretään pelaajaa yksi yksikkö alemmas = kauemmas lonkeroista
            kamera.transform.Translate(new Vector2(kamera.transform.position.x, -6)); //Siirretään kameraa myös alaspäin
            Destroy(other.gameObject); //Tuhotaan poweruppi
        }

        if (other.tag == "Darkness")//Jos toisen objektin tagi on "Darkness"...
        {
			sproot.Play ();
			Invoke ("Death", 4);
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
