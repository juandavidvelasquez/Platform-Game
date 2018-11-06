
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Arma))]

public class Jugador : Personaje
{
    //varibales publicas
    public Slider sliderSalud;
    public Slider sliderEscudo;
    public GameObject Escudo;
    public GameObject activarGameOver;
    public Arma arma;
    public static Transform player;
    public AudioSource activarSonidoAlDisparar;
    float Velocidad = 12;
    float Rotar = 100;
    public bool usaEscudo;
    public float durabilidadEscudo;


    //referencia
    private void Awake()
    {
        //referencia, si el aliado se convierte en enemigo perseguira al jugador
        player = transform;
    }

    //Llamando metodos de caminar, escudo y disparo
    private void Update()
    {
        //si se presiona click izquierdo se activara el metodo de disparo y el sonido
        if (Input.GetButtonDown("Fire1"))
        {
            arma.Disparar();
            activarSonidoAlDisparar.Play();
        }
        //llamando metodos de caminar y activar escudo
        Caminar();
        ActivarEscudo();
    }

    //metodo para recibir daño
    public override void RecibirDaño(float daño)
    {
        //si no se usa el escudo el jugador recibira el daño indicado desde el inspector sino el escudo recibira el daño
        if (!usaEscudo)
        {
            vida -= daño;
        }

        else
        {
            durabilidadEscudo -= daño * 2;
        }

        sliderEscudo.value = durabilidadEscudo;
        sliderSalud.value = vida;

        //si la vida se agota se activara el panel de game over
        if (vida <= 0)
        {
            activarGameOver.SetActive(true);
        }
    }

    //metodo para mover al jugador por el escenario
    void Caminar()
    {
        float translation = Input.GetAxis("Vertical") * Velocidad;
        float rotation = Input.GetAxis("Horizontal") * Rotar;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(new Vector3(0, rotation, 0));
    }

    //metodo para activar el escudo del jugador
    void ActivarEscudo()
    {
        if (Input.GetButton("Fire2"))
        {
            Escudo.SetActive(true);
            sliderEscudo.value -= Random.Range(15, 25) * Time.deltaTime;
        }
        else
        {
            Escudo.SetActive(false);
        }
       
    }
}
