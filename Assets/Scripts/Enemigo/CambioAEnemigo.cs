using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CambioAEnemigo : MonoBehaviour
{
    //variables privadas pero mostradas en el inspectr
    [SerializeField] protected NavMeshAgent nav;
    [SerializeField] protected GameObject aliado;
    [SerializeField] Transform mirar;

    //variables publicas
    public Transform jugadorPrincipal;
    public GameObject enemigoNuevo;
    //variable privada
    bool verifica;

    //enumeraciones para saber si es aliado o enemigo
    public AliadoEnemigo Cambio;
    public enum AliadoEnemigo
    {
        Aliados, enemigos
    }

    void Update()
    {
        //si la condicion de verifica es verdadera el enemigo nuevo perseguira a nuestro jugador
        if (verifica == true)
        {
            nav.SetDestination(Jugador.player.position);
        }   
    }

    public void OnTriggerEnter(Collider other)
    {
        //si el aliado entra en el tag del enemigo, el enemigo lo convertira en enemgio del jugador
        if (other.gameObject.tag == "enemigo")
        {
            Debug.Log("ENTRO AL TRIGGER DEL ENEMIGO");
            //al colisionar se cambia la enumeracion de aliado a enemigo
            Cambio = AliadoEnemigo.enemigos;
            //se desactiva el aliado si el enum pasa a enemigo
            aliado.SetActive(false);
            //Llamando el metodo convertir
            Convertir();
        }
        if (other.gameObject.tag == "Player")
        {
            //si el enemigo detecta en su collision un tag nombrado player, se activa la condicion de verifica
            //y activara la funcion update, la cual contiene la posicion del jugador
            verifica = true;
        }
    }
    
    public void Convertir()
    {
        //si aliado no existe se activara la instancia del otro 
        if (aliado.activeSelf == false)
        {
            Debug.Log("cambio de aliado a enemigo");
            //destruir al aliado para instanciar un nuevo enemigo
            Destroy(aliado);
            //instanciar un nuevo enemigo y destruir el aliado
            GameObject instanciaNuevoEnemigo = Instantiate(enemigoNuevo, aliado.transform.position, Quaternion.identity);
            
        }   
    }
}
