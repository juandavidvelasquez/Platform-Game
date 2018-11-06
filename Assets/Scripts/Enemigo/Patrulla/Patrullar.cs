using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrullar : MonoBehaviour
{
    //variables
    [SerializeField] NavMeshAgent nav;
    [SerializeField] GameObject Enemigo;
    public Transform Objetivo;
    Transform Objetivo2;

    void Start()
	{
		if (nav == null) 
		{
			nav = GetComponent<NavMeshAgent> ();
		}
			
	}

	void Update()
	{
        //El enimigo ira a la primera posicion
		nav.SetDestination (Objetivo.position);
	}

	//patrullar
	void OnTriggerEnter(Collider other)
	{
        //Si el enemigo detecta un tag llamao enemigo(el cual sera el mismo) ira a la posicion anterior
        //de este modo estara patrullando de un punto a otro
		if (other.gameObject.tag == "enemigo")
		{
            //Cambiara de objetivo en objetivo, asi estara caminando de un lado a otro
			other.gameObject.GetComponent<Patrullar>().Objetivo = Objetivo2;
		}
	}
}
