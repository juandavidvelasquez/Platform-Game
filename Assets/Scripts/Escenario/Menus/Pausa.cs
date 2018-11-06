using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    //Variables publicas
    public GameObject UIJugador;
    public GameObject Jugador;

    //variables privadas
    [SerializeField] GameObject Menu;
    [SerializeField] GameObject desactivartiempo;
    [SerializeField] GameObject desactivarEnemigos;
    [SerializeField] GameObject desactivarAliados;
    [SerializeField] GameObject ApagarPlatform;

    //la funcion de bool me sirve para verificar si esta activado o desactivado el canvas
    public bool Pause;

    public void Start()
    {
        Pause = false;
    }
    public void Update()
    {
        //Llamando el metodo de activar el menu de pausa
        ActivarMenuPausa();
    }

    public void ActivarMenuPausa ()
    {

        if (Input.GetKeyUp(KeyCode.P) && Pause == false)
        {
            Pause = true;
            //Activar el menu de pausa al presionar P
            Menu.SetActive(true);
            //Desactivar la interfaz del jugador
            UIJugador.SetActive(false);
            //Desactivar al jugador
            Jugador.SetActive(false);
            //Desactivar tiempo
            desactivartiempo.SetActive(false);
            //Apagar Enemigos
            desactivarEnemigos.SetActive(false);
            //Apagar Plataforma
            ApagarPlatform.SetActive(false);
            //Apagar Aliados
            desactivarAliados.SetActive(false);
        }

        else if (Input.GetKeyUp(KeyCode.P) && Pause == true)
        {
            Pause = false;
            Menu.SetActive(false);
            //Activar la interfaz grafica
            UIJugador.SetActive(true);
            //Activar al jugador
            Jugador.SetActive(true);
            //Activar tiempo
            desactivartiempo.SetActive(true);
            //Encender Enemigos
            desactivarEnemigos.SetActive(true);
            //Encender Plataforma
            ApagarPlatform.SetActive(true);
            //Encender Aliados
            desactivarAliados.SetActive(true);
        }
    }

}
