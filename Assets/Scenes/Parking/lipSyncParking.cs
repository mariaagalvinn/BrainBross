using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class lipSyncParking : MonoBehaviour
{
    public Canvas dialogoToad;
    public Text textoDialogo;
    // Cambia las frases según tu juego


    public  string[] frases;
    private int indice = 0;
    public BakedDataTest bakedDataTest;
    public Button button;

    public string nivel;
    
    void Start()
    {
        MostrarSiguienteFrase(); // Muestra la primera frase
    }
    
    public void onClick()
    {
        Debug.Log("Click");
        MostrarSiguienteFrase();
    }

    void MostrarSiguienteFrase()
    {
        // Comprueba si aún quedan frases por mostrar
        if (indice < frases.Length)
        {
            // Muestra la siguiente frase y avanza el índice
            textoDialogo.text = frases[indice];
            bakedDataTest.PlayBakedData(indice+1);
            indice++;
        }
        else {
            // Cambiar tu juego
            SceneManager.LoadScene(22);
        }
    }
}
