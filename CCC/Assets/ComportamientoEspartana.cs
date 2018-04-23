using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoEspartana : MonoBehaviour {

	Animator myAnimator;

	public float attackRange;
	public float health;
	GameObject[] persians;
	public GameObject flecha;
	public float masCercano = 5f;


	// Use this for initialization
	void Start () {


		myAnimator = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () {


		//chquear rango de ataque:
		//1. 
		persians = GameObject.FindGameObjectsWithTag("persa");
		GameObject persaMasCercano;
		foreach (GameObject persa in persians) {
			if(Vector3.Distance(transform.position, persa.transform.position)<=masCercano){
				masCercano = Vector3.Distance (transform.position, persa.transform.position);
				persaMasCercano = persa;
			//calcular distancia a cada persa:


			//obtener objeto cuya distancia es menor:


			//girar hacia objeto:


			//cargar clip de animacion de ataque:


			//lanzar flecha:
		}
		
	}
}
}
