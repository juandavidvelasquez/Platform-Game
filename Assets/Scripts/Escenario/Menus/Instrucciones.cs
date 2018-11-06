using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrucciones : MonoBehaviour {

    //variable publica
    public GameObject activarInstruccionesPanel;

    private void OnTriggerEnter(Collider other)
    {
        //si un tag llamado player colisiona con este objeto que tiene este scritp se activara el panel de instrucciones
        if (other.gameObject.tag == "Player")
        {
            activarInstruccionesPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //si un tag llamado player sale de la colision se desactivara el panel de instrucciones
        if (other.gameObject.tag == "Player")
        {
            activarInstruccionesPanel.SetActive(false);
        }
    }
}
