using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desactivar_PuertaDos : MonoBehaviour 
{
    //varibles publicas
	public GameObject PuertaDos;
	public GameObject Cubo;


	//Desactivar puerta dos y cambiarle el color a nuestro jugador para que pueda avanzar
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Cubo1") 
		{
			PuertaDos.SetActive (false);
			//Al entrar en el trigger un tag llamado cubo1 el jugador cambiara de color azul, lo cual permite que pueda avanzar
			Cubo.GetComponent<Renderer> ().material.color = Color.black;
		}
	}

	void OnTriggerExit(Collider other)
	{
        //si el cubo sale de la colision la puerta sera activada de nuevo
		if (other.gameObject.tag == "Cubo1") 
		{
			PuertaDos.SetActive (true);
			Cubo.GetComponent<Renderer> ().material.color = Color.green;
		}
	}
		
}

