using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GanarVolverAMenu : MonoBehaviour {

    //si el jugador gana el juego vuelve al menu atumaticamente
    public void Volver()
    {
            SceneManager.LoadScene(0);
    }
}
