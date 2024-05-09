using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Guardar_Posicion : MonoBehaviour {

	public float PosX;
	public float PosY;
	public float PosZ;


	public Vector3 Posicion;


	void Start () {
		CargarDatos ();
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.F6)){
			GuardarDatos ();
		}
		if(Input.GetKeyDown(KeyCode.F7)){
			GuardarDatos ();
		}
	}
	public void GuardarDatos(){
		PlayerPrefs.SetFloat ("PosicionX", transform.position.x);
		PlayerPrefs.SetFloat ("PosicionX", transform.position.y);
		PlayerPrefs.SetFloat ("PosicionX", transform.position.z);
		Debug.Log ("Datos guardados correctamente");
	}
	public void CargarDatos(){
		PosX = PlayerPrefs.GetFloat("PosicionX");
		PosY = PlayerPrefs.GetFloat("PosicionY");
		PosZ = PlayerPrefs.GetFloat("PosicionZ");
		
		Posicion.x = PosX;
		Posicion.y = PosY;
		Posicion.z = PosZ;

		
		transform.position = Posicion;

	}
}


