using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desactivarRejasFinal : MonoBehaviour {

    //variable privada
    [SerializeField] GameObject destruirPuerta;


    void OnTriggerEnter(Collider other)
    {
        //si el tag player entra en la colision del objeto con este script se desactivaran las rejas del piso final
        if (other.CompareTag("Player"))
        {
            Debug.Log("Desactivar");
            Destroy(destruirPuerta);
        }
    }
}
