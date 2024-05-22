using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenas : MonoBehaviour
{
    
    public string Juego = "Juego";

  
    public void CambiarEscena1()
    {
        SceneManager.LoadScene(21);
    }

    public void CambiarEscenaPrincipal()
    {
        SceneManager.LoadScene("Mapa 5");
    }
    
}
