
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Arma))]

public class Enemigo : Personaje
{
    //variables publicas
    public ParticleSystem particulasMuerte;
    public GameObject cuerpoTorreta;
    public Transform transformTorreta;
    public Arma arma;
    public Jugador activarEscudo;
    public bool puedeDisparar;
    public bool hayTarget;

    [SerializeField] Animator animaPausa;

    private void Start()
    {
        //iniciando la animacion de la torreta
        animaPausa.enabled = true;
    }

    private void Update()
    {
        /* si la verificacion de puede disparar y hayTarget se cumplen se activara el 
         * metodo de disparo y se le hara llamado a la corrutina para darle el tiempo de disparo */
        if (puedeDisparar && hayTarget)
        {
            puedeDisparar = false;
            arma.Disparar();
            StartCoroutine(Recargar());
        }
    }

    public override void RecibirDaño(float daño)
    {
        //si la vida de la torreta llega a cero se activaran las particulas y se destruira
        vida -= daño;

        if (vida <= 0)
        {
            Destroy(gameObject,0.5f);
            cuerpoTorreta.SetActive(false);
            particulasMuerte.Play();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            /* si un tag nombrado player entrar al trigger la animacion se pausara 
             * y seran verdaderas las condiciones de disparo y target */
            puedeDisparar = true;
            hayTarget = true;
            animaPausa.enabled = false;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        /*si un tag nombrado player entra en el trigger la torreta se fijara en mirarlo 
         * para poder atacarlo */
        if (other.gameObject.tag == "Player")
        {
            transformTorreta.LookAt(other.transform);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        /*si un tag nombrado player sale del trigger las condiciones 
          puedeDisparar y hayTarget seran falsas, y la animacion continuara*/
        if (other.gameObject.tag == "Player")
        {
            puedeDisparar = false;
            hayTarget = false;
            animaPausa.enabled = true;
        }
    }

    IEnumerator Recargar()
    {
        //corrutina para darle el tiempo de disparo a la torreta
        yield return new WaitForSeconds(0.2f);
        puedeDisparar = true;
    }
}

