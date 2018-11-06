using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HLaserCausaDaño : MonoBehaviour
{

    //variable publica
	public GameObject Jugador;
    public Jugador rebajaSalud;
  

    void OnCollisionEnter(Collision other)
	{
        //si el tag player entra en esta colsion su salud perdera 60 puntos
        if (other.gameObject.tag == "Player")
        {
            rebajaSalud.sliderSalud.value -= 100;
        }
 

	}
}
