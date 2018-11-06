using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DañoRayo : MonoBehaviour
{
    //variable publica daño al jugador
    public GameObject jugadorExplosion;
    public GameObject activarGameOver;
    //llamando scripts
    public CameraFilterPack_FX_Drunk2 activarCameraEfecto;
    public Pausa desactivarUI;
    public ActivarTiempo desactivartiempo;

    public void OnTriggerEnter(Collider other)
    {
        //si un tag llamado player colisiona con los rayos se activara el efecto de la camara
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Efecto de la camara se activo");
            activarCameraEfecto.enabled = true;
            //iniciando la corrutina activarcamera
            StartCoroutine(activarcamera());
        }
    }

    IEnumerator activarcamera()
    {
        //si el player colisiona con los rayos se destruira despues de 2.5(al pasar el efecto de la camara)
        Debug.Log("inicio de corrutina para destruir al jugador");
        yield return new WaitForSeconds(2.5f);
        Destroy(jugadorExplosion);
        //al pasar 2.5 segundos se activara el panel de game over
        activarGameOver.SetActive(true);
        //al estar activado el panel de game over se desactivara la UI de usuario y el tiempo
        desactivarUI.UIJugador.SetActive(false);
        desactivartiempo.TiempoInicia.SetActive(false);
        //al pasar 3 segundos de que el panel este activado volvera al menu de forma automatica
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);

 
    }
}
