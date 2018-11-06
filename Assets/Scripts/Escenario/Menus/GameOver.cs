using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameOver : MonoBehaviour {

    //Variables publicas
    public GameObject PanelGameOver;
    public GameObject DesactivarTextoBotonPuertaUno;
    int nivel;
    //llamando scripts
    [SerializeField] Jugador sliderRebajarSalud;
    [SerializeField] Pausa DesactivarUI;
    [SerializeField] ActivarTiempo DesactivarTime;
    [SerializeField] AsyncOperation asy;
    

    public void Update()
    {
        //Llamando el metodo de muerto
        Muerto(nivel);
        
    }

    public void Muerto(int nivel)
    {
        /*si la salud del jugador llega a cero se desactivara la UI, el jugador y el tiempo, y se
         *activara el panel de game over*/

        if (sliderRebajarSalud.sliderSalud.value == 0)
        {
            //Inicio de la corrutina 
            StartCoroutine(Reinicio(nivel));
            //Desactivar Menus cuando el personaje muere
            PanelGameOver.SetActive(true);
            DesactivarUI.GetComponent<Pausa>().UIJugador.SetActive(false);
            DesactivarUI.GetComponent<Pausa>().Jugador.SetActive(false);
            DesactivarTime.GetComponent<ActivarTiempo>().TiempoInicia.SetActive(false);
            DesactivarTextoBotonPuertaUno.SetActive(false);
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    IEnumerator Reinicio(int nivel)
    {
        //Al presionar click en el boton volveremos al menu para iniciar de nuevo el gameplay
        if (Input.GetButton("Fire1"))
        {
            asy = SceneManager.LoadSceneAsync(nivel);
            yield return null;
            PanelGameOver.SetActive(true);
            sliderRebajarSalud.sliderSalud.value = asy.progress;
        }
    }
}
