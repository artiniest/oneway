using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour 
{
    public GameObject [] eyes;
    public GameObject [] powerups; //Array powerupeille, tästä spawnataan
    public GameObject [] spawnedPowerups; //Array spawnatuille powerupeille
    public GameObject[] obstacles; //Array esteille, tästä spawnataan
	public GameObject[] spawnedObstacles; //Array scenessä aktiivisille esteille
	public GameObject[] tracks; //Array radoille
    public GameObject [] background; //Array taustoille
	public float moveSpeed = 10f; //Liikkumisnopeus esteille

    Vector3 returnpos = new Vector3 (0, -45, 10); //Palauspiste taustalle

	void Start ()
	{
		InvokeRepeating ("SpawnObs", 1, 2); //Kuinka usein Spawn-funktio käynnistetään
        InvokeRepeating("SpawnPower", 2, 3); //Kuinka usein Poweruppeja spawnataan
        InvokeRepeating("SpawnEyes", 3, 2);
	}

	void Update ()
	{
		spawnedObstacles = GameObject.FindGameObjectsWithTag ("Obstacle"); //Etsii objekteja Obstacle-tagilla ja lisää ne listaan
        spawnedPowerups = GameObject.FindGameObjectsWithTag("Powerup"); //Etsii objekteja Powerup-tagilla ja lisää ne listaan
	}

	void FixedUpdate()
	{
		foreach (GameObject obj in spawnedObstacles) //Jokainen spawnedObstables-arrayn objekti liikkuu tietyn verran y-akselilla
		{
			obj.transform.Translate (new Vector2 (0, moveSpeed * Time.deltaTime));
		}

        foreach (GameObject power in spawnedPowerups) //Jokainen spawnedPowerup-arrayn objekti liikkuu tietyn verran y-akselilla
        {
            if (power != null)
            {
                power.transform.Translate(new Vector2(0, moveSpeed * Time.deltaTime));
            }
        }

        foreach (GameObject bg in background) //Taustojen liike ja palautus
        {
            bg.transform.Translate(new Vector2(0, moveSpeed * Time.deltaTime));

            if (bg.transform.position.y > 30)
            {
                bg.transform.position = returnpos;
            }
        }
	}

	void SpawnObs ()
	{
        Instantiate(obstacles [Random.Range(0, obstacles.Length)], tracks [Random.Range(0, tracks.Length)].transform.position, Quaternion.identity);
        Instantiate (obstacles[Random.Range(0, obstacles.Length)], tracks[Random.Range(0, tracks.Length)].transform.position, Quaternion.identity); //Spawnataan obstacles-listasta indexin -->
        //mukainen objekti, randomille radalle.
    }

    void SpawnPower ()
    {
        int powerRandomizer = Random.Range(0, 5); //Randomisoidaan milloin poweruppeja spawnaa
        if (powerRandomizer == 2)
        {
            Instantiate(powerups [Random.Range(0, powerups.Length)], tracks [Random.Range(0, tracks.Length)].transform.position, Quaternion.identity); //Spawnataan powerups-listasta indexin -->
            //mukainen objekti, randomille radalle.
        }
    }

    void SpawnEyes ()
    {
        int eyeRandomizer = Random.Range(0, 8); 
        int eyeToSpawn = Random.Range(0, eyes.Length);
        switch (eyeRandomizer)
        {
            case 02:
                Instantiate(eyes [eyeToSpawn], new Vector3(eyes[eyeToSpawn].transform.position.x, -45, eyes[eyeToSpawn].transform.position.z), Quaternion.identity);
                break;
        }
    }
}
