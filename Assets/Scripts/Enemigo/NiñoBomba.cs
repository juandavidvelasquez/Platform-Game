using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NiñoBomba : Personaje
{
    //Variables publicas
    public GameObject destruirNiñoBomba;
    public ParticleSystem particulasMuerte;
    public Jugador activarEscudo;
    public float daño; 

    public override void RecibirDaño(float daño)
    {
        vida -= daño;

        //si la vida del niño bomba llega a cero se destruira y activa las particulas de explosion
        if (vida <= 0)
        {
            Destroy(gameObject, 0.5f);
            particulasMuerte.Play();
        }
  
    }

    private void OnTriggerEnter(Collider other)
    {
        //si el jugador entra en el trigger del niño bomba le causa daño y se destruira el niño bomba
        if (other.GetComponent<Personaje>())
        {
            other.GetComponent<Personaje>().RecibirDaño(daño);
            Destroy(gameObject, 0.25f);
            particulasMuerte.Play();
            //si el escudo esta activo le causa un daño menor a la vida
            if (other.GetComponent<Jugador>().Escudo.activeSelf)
            {
                //other.GetComponent<Personaje>().vida = vida;
                activarEscudo.durabilidadEscudo -= daño;
                activarEscudo.sliderEscudo.value = activarEscudo.durabilidadEscudo;
            }
            
        }


    }
}
