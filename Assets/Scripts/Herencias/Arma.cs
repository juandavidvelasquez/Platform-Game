using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    //variables publicas
    public GameObject disparo;
    public float daño = 50;

    //variable Raycasthit la cual me devolvera informacion cuando colisione con algo
    public RaycastHit hit;

    //metodo de disparo, el cual sera llamado desde el jugador y el enemigo(Torreta)
    public void Disparar()
    {
        //inicio de la corrutina mostrardisparo
        StartCoroutine(MostrarDisparo());

        //indicando las posiciones hacia donde ira dirigido el Raycast
        Ray ray = new Ray(disparo.transform.position, disparo.transform.forward);
      
        if (Physics.Raycast(ray, out hit, 100))
        {
            //llamando la clase personaje la cual contiene la variable de daño
            if (hit.transform.GetComponent<Personaje>())
                hit.transform.GetComponent<Personaje>().RecibirDaño(daño);
         }
    }

    IEnumerator MostrarDisparo()
    {
        //Esta corrutina esta creada para que el arma del jugador dispare cada 0.2 segundos
        disparo.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        disparo.SetActive(false);
    }
}
