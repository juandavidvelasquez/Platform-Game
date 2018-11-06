using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioFondo : MonoBehaviour {

    //varible publica
    public AudioSource musicaFondo;

    private void Start()
    {
        //inicio de auido de fondo
        musicaFondo.Play();
    }
}
