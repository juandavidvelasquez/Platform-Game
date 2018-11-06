using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class RecogerFinal : MonoBehaviour
{
    //variables privadas
    [SerializeField] GameObject ObjetoFinal;
    [SerializeField] GameObject ActivarGanaste;
    [SerializeField] AudioSource ActivarSonido;
    [SerializeField] Pausa Desactivar;
    [SerializeField] GameObject Creditos;

    //llamando script
    public ActivarTiempo DesactivarTiempo;
    public AudioFondo desactivarMusicadeFondo;

    private void Start()
    {
        //pausar musica de fondo
        ActivarSonido.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            //si un tag llamado player recoje el objeto final este se desactivara y se activara la camara de ganar
           ObjetoFinal.SetActive(false);
            //llamando al metodo activar camara final
           ActivarCamaraFinal();
        }
    }

    void ActivarCamaraFinal()
    {
        if (ObjetoFinal.activeSelf == false)
        {
            //activar el panel de ganar
            Debug.Log("Activo panel de ganar");
            ActivarGanaste.SetActive(true);
            //activar sonido de victoria
            ActivarSonido.Play();
        }

        if (ActivarGanaste.activeSelf == true)
        {
            //desactivar UI, el jugador, y el tiempo si el panel de ganar esta activo
            Debug.Log("Desactivar Menu");
            Desactivar.GetComponent<Pausa>().UIJugador.SetActive(false);
            Desactivar.GetComponent<Pausa>().Jugador.SetActive(false);
            DesactivarTiempo.GetComponent<ActivarTiempo>().TiempoInicia.SetActive(false);
            //pausar musica de fondo
            desactivarMusicadeFondo.musicaFondo.Stop();
            //llamando la corrutina de creditos
            StartCoroutine(creditos());
        }
       
    }

    IEnumerator creditos()
    {
        //despues de que el panel de ganar este activo, al pasar 5 segundos se activara el panel de creditos
        if (ActivarGanaste.activeSelf == true)
        {
            yield return new WaitForSeconds(5f);
            Creditos.SetActive(true);
            ActivarGanaste.SetActive(false);

        }
    }


}
