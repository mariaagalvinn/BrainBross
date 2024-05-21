using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenas : MonoBehaviour
{
    
    public string Juego = "Juego";

  
    public void CambiarEscena1()
    {
        Debug.Log("¡Hola, mundo!");
        SceneManager.LoadScene(21);
    }

    public void CambiarEscenaOpciones()
    {
        Debug.Log("¡Hola, mundo!");
        SceneManager.LoadScene(2);
    }

    public void CambiarEscenaPrincipal()
    {
        Debug.Log("¡Hola, mundo!");
        SceneManager.LoadScene(0);
    }
    
}
