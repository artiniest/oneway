using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour 
{
	public GameObject[] obstacles; //Array esteille, tästä spawnataan
	public GameObject[] spawnedObstacles; //Array scenessä aktiivisille esteille
	public GameObject[] tracks; //Array radoille
	public float moveSpeed = 10f; //Liikkumisnopeus esteille

	void Start ()
	{
		InvokeRepeating ("Spawn", 1, 2); //Kuinka usein Spawn-funktio käynnistetään
	}

	void Update ()
	{
		spawnedObstacles = GameObject.FindGameObjectsWithTag ("Obstacle"); //Etsii objekteja Obstacle-tagilla ja lisää ne listaan
	}

	void FixedUpdate()
	{
		foreach (GameObject obj in spawnedObstacles) 
		{
			obj.gameObject.transform.Translate (new Vector2 (transform.position.x, moveSpeed * Time.deltaTime));
		}
	}

	void Spawn ()
	{
		Instantiate (obstacles[0], new Vector2(tracks[Random.Range(0, tracks.Length)].transform.position.x, -15),Quaternion.identity); //Spawnataan obstacles-listasta indexin mukainen objekti, randomille radalle.
	}
}
