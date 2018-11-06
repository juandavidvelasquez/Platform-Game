using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarAyuda : MonoBehaviour {

    //variables publicas
    public GameObject TextoAvatar;
    public Transform Mirar;

    //llamando script
    public NPCcaminarRandomAliado DesactivarCRandom;

    void Start()
    {
        //al iniciar el script de caminar random estara activado
        DesactivarCRandom.enabled = true;
        //al iniciar el juego el texto estara desactivado
        TextoAvatar.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            /*si un tag player entra en esta colision el script de caminar random se desactivara, 
              y se actiaran los textos*/
            DesactivarCRandom.enabled = false;
            //mirar al jugador si entra en la colision
            transform.LookAt(Mirar);
            TextoAvatar.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            /*si un tag palyer sale de esta colision el script de caminar random se activara,
              y se desactivaran los textos*/
            TextoAvatar.SetActive(false);
            DesactivarCRandom.enabled = true;
        }
    }

}
