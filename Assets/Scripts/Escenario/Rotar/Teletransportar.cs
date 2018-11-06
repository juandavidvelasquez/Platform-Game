using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teletransportar : MonoBehaviour {

    //variables publicas
	public Transform Jugador;
	public float x;
	public float y;
	public float z;

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
            //si un tag colsiona con el objeto que tenga este script lo mandara a la posicion que le indiquemos desde el inspector
			Jugador.transform.position = new Vector3 (x, y, z);	

		}
			
	}
}
