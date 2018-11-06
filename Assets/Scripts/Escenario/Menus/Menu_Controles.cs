using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Controles : MonoBehaviour
{
    //Variables publicas
    public GameObject PanelControl;
    public GameObject DesactivarUI;
    //el bool me verifica si el esta activado o desactivado el panel
    bool Verifica;

    private void Start()
    {
        //Al inicio del juego el panel sera desactivada
        PanelControl.SetActive(false);
        Verifica = false;
    }

    private void Update()
    {
        //Al presionar "L" el panel de los controles sera activado
        if (Input.GetKeyDown(KeyCode.L) && Verifica == false)
        {
            Verifica = true;
            PanelControl.SetActive(true);
            DesactivarUI.SetActive(false);
        }
        //Si no se presiona "L" el panel estara desactivado
        else if (Input.GetKeyDown(KeyCode.L) && Verifica == true)
        {
            Verifica = false;
            DesactivarUI.SetActive(true);
            PanelControl.SetActive(false);
        }
    }
}
