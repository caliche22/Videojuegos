using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoPersa : MonoBehaviour {


	GameObject levelManager;


	Vector3[] waypoints = 
	{
		new Vector3(-3.1f,3.7f,-5f),
		new Vector3(-3.8f,2.8f,-5f),
		new Vector3(-4.8f,1.5f,-5f),
		new Vector3(-4.9f,0.5f,-5f),
		new Vector3(-3.4f,0.0f,-5f),
		new Vector3(-1.8f,0.1f,-5f),
		new Vector3(1.2f,-0.7f,-5f),
		new Vector3(5.0f,-1.9f,-5f),
		new Vector3(8.6f,-2.9f,-5f),
		new Vector3(10.3f,-3.3f,-5f)
	};

	int currentWayPoint;
	float speed = 0.01f;

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		currentWayPoint = 0;
		rb = GetComponent<Rigidbody2D> ();


		levelManager =  GameObject.FindGameObjectWithTag("LevelManager");

			
	}
	
	// Update is called once per frame
	void Update () {

		//moverse y chuequear posición
		moversePorWaypoints();

		//si posicion es  (x,y) , debe enviar un mensaje al script principal (PersaAtHome) 

		
	}

	void moversePorWaypoints()
	{

		if (currentWayPoint == waypoints.Length-1) {
			levelManager.SendMessage ("PersaAtHome");
		}


		if (currentWayPoint < waypoints.Length) {
			Vector3 target = waypoints [currentWayPoint];
			//rb.MovePosition (transform.position + target * Time.deltaTime*speed);

			transform.position = Vector3.MoveTowards (transform.position, target, speed);

			if (Vector3.Distance (transform.position, target) < 0.1f) {
				currentWayPoint++;
			}
		}

	}
}
