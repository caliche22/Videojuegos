using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelManager_Script : MonoBehaviour {

	public GameObject Spartano;
	public float totalHealth;
	public float healthPoints_loss;

	public GameObject persa;

	public GameObject sombra;

	GameObject fondo;
	public Text puntos;

	int maxPersas = 50;

	Random aleatorio;

	Vector3 target;
	Vector3 mousePos;
	int X, Y;

	bool todosPersasInstanciados;

	bool region1, region2, region3, region4;

	float startX=-10.0f, startY=4.4f;

	float elapsedTime;

	const int MAX_SECONDS = 22;

	public GUISkin mySkin;

	SpriteRenderer sombraRenderer;

	// Use this for initialization
	void Start () {

		totalHealth = 100f;
		healthPoints_loss = 0.25f;

		aleatorio = new Random ();
		todosPersasInstanciados = false;

		region1 = false;
		region2 = false;
		region3 = false;
		region4 = false;

		fondo = GameObject.FindGameObjectWithTag ("Fondo");


		//sombra = GameObject.FindGameObjectWithTag ("Sombra");



	}

	// Update is called once per frame
	void Update () {


		//chequear si ha pasado un minuto:
		elapsedTime = Time.realtimeSinceStartup;
		//Debug.Log (elapsedTime);

		if (elapsedTime <= MAX_SECONDS) {
			InstanciarEspartanos ();

		} else if(elapsedTime >= MAX_SECONDS && !todosPersasInstanciados){
			//awsome = InstanciarPersas ();	
			StartCoroutine("InstanciarPersas");
			todosPersasInstanciados = true;
		}

	}

	void OnGUI()
	{
		GUI.skin = mySkin;
		
		GUI.Label (new Rect(150,0,100,50),totalHealth.ToString());

	}

	//Color sombraColor;

	/// <summary>
	/// Instanciar espartanos en posición dada por el jugador.
	/// </summary>
	void InstanciarEspartanos()
	{

		//Mostrar regiones donde se pueden crear espartanos:
		if (!region1) {
			Instantiate (sombra, new Vector3 (-4.8f, -0.8f, 0), Quaternion.identity);
			region1 = true;
		}

		//
		Color colorFondo = fondo.GetComponent<SpriteRenderer>().material.color;
		colorFondo.a = 1.0f;
		//

		//Capturar x y y del mouse;
		if (Input.GetMouseButtonUp (0)) {
			mousePos = Input.mousePosition;

			Debug.Log ("mousepos="+mousePos);

			//Convertir coordenadas:
			target=Camera.main.ScreenToWorldPoint(mousePos);

			Debug.Log ("target="+target+" X="+X+", Y="+Y);
			if (target.x>=-4.8f && target.x<=-3.6f && (target.y<=-0.1f && target.y >= -0.8f)) {
				Instantiate (Spartano, new Vector3(target.x-X,target.y-Y,-5), Quaternion.identity);	
				Debug.Log ("opcion 1");
			}

			else if (target.x>=1.0f && target.x<=2.6f && (target.y<=1.5f && target.y >= 0.6f)){
					Instantiate (Spartano, new Vector3(target.x-X,target.y-Y,-5), Quaternion.identity);
				Debug.Log ("opcion 2");
			}

			else if (target.x>=1.9f && target.x<=4.1f && (target.y<=-2.7f && target.y >= -3.3f)){
						Instantiate (Spartano, new Vector3(target.x-X,target.y-Y,-5), Quaternion.identity);
				Debug.Log ("opcion 3");
			}
			else if (target.x>=4.1f && target.x<=5.6f && (target.y<=-0.6f && target.y >= -1.2f)){
							Instantiate (Spartano, new Vector3(target.x-X,target.y-Y,-5), Quaternion.identity);
				Debug.Log ("opcion 4");
			}

			//



			//Instanciar objeto:
			//Instantiate (Spartano, new Vector3(target.x-X,target.y-Y,-5), Quaternion.identity);

		}
	}


	//Mensaje recibido cada que llegue un persa
	void PersaAtHome()
	{
		totalHealth -= healthPoints_loss;
	}



	IEnumerator InstanciarPersas()
	{
		float delay = Time.time;
		int i = 0;
		while(i<maxPersas){
			if(Time.time-delay>1){
			Debug.Log ("Instanciando persas "+(i+1)+"...");
			Instantiate (persa, new Vector3 (-3.6f, 2.5f, -5), Quaternion.identity);
			i++;
			delay=Time.time;
			}
			yield return null;	
		}	

	}
}
