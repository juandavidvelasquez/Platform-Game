using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAvatarAle : MonoBehaviour {

    //variables privadas
    [SerializeField] GameObject Canvas;
    [SerializeField] GameObject Texto1;
    [SerializeField] GameObject Texto2;
    [SerializeField] GameObject Texto3;
    [SerializeField] Transform Mirar;

    //llamando script
    public NPCcaminarRandomAliado DesactivarCRandom;

    private void Start()
    {
        //Textos desactivados al iniciar 
        Canvas.SetActive(false);
        Texto1.SetActive(false);
        Texto2.SetActive(false);
        Texto3.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //iniciar corrutina
            StartCoroutine(DesactivarTexto());
            Canvas.SetActive(true);
            Texto1.SetActive(true);
            //mirar jugador
            transform.LookAt(Mirar);
            /*si un tag player entra en esta colision el script de caminar 
              random se desactivara, y se avtivaran los textos*/
            DesactivarCRandom.enabled = false;

        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            /*si un tag player sale de esta colision el script de caminar 
              random se activara, y se desactivaran los textos*/
            Texto1.SetActive(false);
            Canvas.SetActive(true);
            transform.LookAt(Mirar);
            DesactivarCRandom.enabled = true;
        }
    }

    IEnumerator DesactivarTexto()
    {
        //activa el texto inicial, y al pasar 4 segundos lo desactiva y activa el texto siguiente
        yield return new WaitForSeconds(3);
        Texto1.SetActive(false);
        Texto2.SetActive(true);
        //activa el texto anterior, y al pasar 4 segundos lo desactiva y activa el texto siguiente
        yield return new WaitForSeconds(3);
        Texto2.SetActive(false);
        Texto3.SetActive(true);
        //activa el texto final, y al pasar 4 segundos lo desactiva.
        yield return new WaitForSeconds(5);
        Texto3.SetActive(false);

    }
}
