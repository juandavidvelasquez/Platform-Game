using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ActivarTiempo : MonoBehaviour
{
    //variables publicas
    public GameObject TiempoInicia;
    public GameObject ParedBloquear;
    public GameObject PararTiempo;
    public Text texto;
    public float tiempo;

    //Llamando al script Pausa
    public Pausa DesactivarUI;


    private void Start()
    {
        //tiempo y pared de bloqueo se inician en falso
        TiempoInicia.SetActive(false);
        ParedBloquear.SetActive(false);
    }

    public void Update()
    {
        //Si el jugador colisiona con la pared activara un canvas con el tiempo dado para realizar la mision
        if (ParedBloquear.activeSelf == true)
        {
            tiempo = tiempo - 1 * Time.deltaTime;
            ////ToString quita los decimales, ya que el temporizador es un float
            texto.text = "" + tiempo.ToString("0:00");

            //si el tiempo se termina, automaticamente volvera al menu
            if (tiempo <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //si un tag llamado player colisiona con la pared el tiempo se iniciara
        //y la pared de bloqueo sera falsa
        if (other.gameObject.tag == "Player")
        {
            TiempoInicia.SetActive(true);
            ParedBloquear.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //la pared se activara para que el jugador no se devuelva
        if (other.gameObject.tag == "Player")
        {
            ParedBloquear.SetActive(true);
        }
    }

}
