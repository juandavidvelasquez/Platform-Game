using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Personaje : MonoBehaviour
{
    //Clase principal de la cual heredara el personaje principal y los enemgios
    [SerializeField]
    public float vida;

    //metodo abstract el cual sera usado por el personaje y los enemigos
    public abstract void RecibirDaño(float daño);

}
