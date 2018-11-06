using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarVolverHijo : MonoBehaviour 
{
    //variables publicas
	public GameObject Plataforma;
	public float Tiempo;
	public float x;
	public float y;
	public float z;

	void Update () 
	{
        //Posicion hacia donde rotara, y el tiempo(Velocidad)
		Plataforma.transform.Rotate (new Vector3 (x, y, z) * Tiempo);
	}

	void OnCollisionEnter(Collision other)
	{
		print (1);
		if (other.gameObject.tag == "Player") 
		{
			print (2);
            //Si un tag "Player" colisiona con este objeto lo volvera hijo
			other.transform.SetParent (transform);
		}
	}
	void OnCollisionExit(Collision other)
	{
		if (other.gameObject.tag == "Player") 
		{
            //Si el tag "Player" sale de la colision la opcion de volver hijo sera cancelada
			other.transform.SetParent (null);
		}
	}
}
