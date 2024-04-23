using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boton2 : MonoBehaviour
{
    public void CambiarAEscena()
    {
        // Cargar la escena indicada
        SceneManager.LoadScene("2CrossingRoad");
    }
}
