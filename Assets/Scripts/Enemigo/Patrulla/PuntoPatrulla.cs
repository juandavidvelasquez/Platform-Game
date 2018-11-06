using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoPatrulla : MonoBehaviour {

    //variable publica
    public Transform ObjetivoPatrullar;

    void OnTriggerEnter(Collider other)
    { 
        /*si el empty detecta en su colision un tag llamado enemigo le asignara la posicion anterior
          Asi el enemigo patrullara de un punto a otro*/
		if (other.gameObject.tag == "enemigo")
		{
			other.gameObject.GetComponent<Patrullar>().Objetivo = ObjetivoPatrullar;
		}
}
}
