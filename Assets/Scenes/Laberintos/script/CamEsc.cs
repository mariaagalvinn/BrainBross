using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamEsc : MonoBehaviour
{
    public string Juego;

    public void VolverMapa()
    {
        Debug.Log("¡Hola, mundo!");
        SceneManager.LoadScene(12);
    }

    public void Laberinto1()
    {
        Debug.Log("¡Hola, mundo!");
        SceneManager.LoadScene(25);
    }

}
