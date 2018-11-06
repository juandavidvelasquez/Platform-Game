
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarPuertaTres : MonoBehaviour 
{
    //variable publica
	public GameObject puertaTres;

	void OnTriggerStay(Collider other)
	{
        //si el tag esfera colisiona con el objeto que tenga este script se desactivara la puerta numero 3
		if (other.gameObject.tag == "Esfera") 
		{
            puertaTres.SetActive (false);

		}
	}

}
