using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCcaminarRandomAliado : MonoBehaviour {

    //variables publicas
    [SerializeField] NavMeshAgent Nav;
    [SerializeField] int tiempo;
    [SerializeField] float velocidad;
    //varibales privadas
    bool tiempogiro;
    float y;

    void Start()
    {
        Nav = GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        tiempo += 1;
        transform.Translate(transform.forward * velocidad * Time.fixedDeltaTime);
        transform.Rotate(new Vector3(0, y, 0));

        //Tiempo random en el que el aliado cambiara de posicion
        if (tiempo >= Random.Range(100, 2500))
        {
            Girar();
            tiempo = 0;
            tiempogiro = true;
        }

        if (tiempogiro == true)
        {
            if (tiempo >= Random.Range(1, 10))
            {
                y = 0;
                tiempogiro = false;
            }
        }
    }

    public void Girar()
    {
        y = Random.Range(-45, 45);
    }
}
