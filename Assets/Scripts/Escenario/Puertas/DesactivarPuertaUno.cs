using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesactivarPuertaUno : MonoBehaviour 
{
    //variables publicas
	public GameObject Desactivar;
	public GameObject PresioneE;
	public GameObject partejugador0;
	public GameObject partejugador1;
	public GameObject partejugador2;
	public GameObject partejugador3;
	public LineRenderer cambiocolor;


	// si el jugador se mantiene en la colision tendra que presionar la tecla E para desactivar la puerta y continuar
	void OnTriggerStay (Collider other) 
	{
		if (Input.GetKey(KeyCode.E)) {
            cambiocolor.GetComponent<LineRenderer>().SetColors(Color.green, Color.green);
            //al presionar E la puerta se desactivara
			Desactivar.SetActive (false);
			//El jugador cambiara de color al tocar el boton
			partejugador0.GetComponent<Renderer> ().material.color = Color.black;
			partejugador1.GetComponent<Renderer> ().material.color = Color.green;
			partejugador2.GetComponent<Renderer> ().material.color = Color.green;
			partejugador3.GetComponent<Renderer> ().material.color = Color.green;
			GameObject.FindGameObjectWithTag ("Player").GetComponentInChildren<Light> ().color = Color.green;
		}

	}

	//Activar y Desactivar el texto de presionar E para continuar
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			Debug.Log ("Entro");
			PresioneE.SetActive (true);
		} 
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			Debug.Log ("Salio");
			PresioneE.SetActive (false);
		} 
	}
}
