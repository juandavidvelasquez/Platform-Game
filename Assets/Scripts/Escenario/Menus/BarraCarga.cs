using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarraCarga : MonoBehaviour {

    //variables publicas
    public GameObject imagenBarra;
    public GameObject desactivarMenu;
    public Slider barra;
    private AsyncOperation asy;

    public void clickcarga(int nivel)
    {
        //activar interfaz de barra de carga y llamando la corrutina de cargar nivel
        imagenBarra.SetActive(true);
        desactivarMenu.SetActive(true);
        StartCoroutine(CargarNivel(nivel));
    }

    //corrutina que me permite hacer la carga del nivel
    IEnumerator CargarNivel(int nivel)
    {
        asy = SceneManager.LoadSceneAsync(nivel);
        while (!asy.isDone)
        {
            //desactivo el panel de menu, y doy inicio a la barra de carga
            desactivarMenu.SetActive(false);
            barra.value = asy.progress;

            yield return null;
        }
    }
}
