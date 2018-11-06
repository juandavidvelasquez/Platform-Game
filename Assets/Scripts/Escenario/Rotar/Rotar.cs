using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotar : MonoBehaviour {

    //variables publicas
	public GameObject Plataforma;
	public float Tiempo;
	public float x;
	public float y;
	public float z;

	void Update () 
	{
        //rotar en las posiciones indicadas
		Plataforma.transform.Rotate (new Vector3 (x, y, z) * Tiempo);
	}

}
