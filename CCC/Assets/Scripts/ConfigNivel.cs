using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigNivel : MonoBehaviour {

	public GameObject Spartano;
	public float totalHealth;
	public float healthPoints_loss;

	Vector3 mousePos;
	int X, Y;

	float elapsedTime;

	// Use this for initialization
	void Start () {
		
		totalHealth = 100f;
		healthPoints_loss = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {


		//chequear si ha pasado un minuto:
		elapsedTime = Time.time;

		if (elapsedTime >= 180) {
			InstanciarPersas ();	
		} else {
			InstanciarEspartanos ();
		}



	}

	/// <summary>
	/// Instanciar espartanos en posición dada por el jugador.
	/// </summary>
	void InstanciarEspartanos()
	{
		//Capturar x y y del mouse;
		if (Input.GetMouseButtonUp (0)) {

			mousePos = Input.mousePosition;

			//Convertir coordenadas:


			//Instanciar objeto:
			Instantiate (Spartano, new Vector3(mousePos.x-X,mousePos.y-Y,-5), Quaternion.identity);

		}
	}


	//Mensaje recibido cada que llegue un persa
	void PersaAtHome()
	{
		totalHealth -= healthPoints_loss;
	}

	void InstanciarPersas()
	{
		//
	}
}
