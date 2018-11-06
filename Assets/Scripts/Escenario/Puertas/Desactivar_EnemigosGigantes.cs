using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desactivar_EnemigosGigantes : MonoBehaviour {

    public CambioAEnemigo desactivarEnemigo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            desactivarEnemigo.enemigoNuevo.SetActive(false);
        }
    }
}
