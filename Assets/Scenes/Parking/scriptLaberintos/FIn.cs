using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FIn : MonoBehaviour
{
    public int puntuacion = 0;
    public int total = 11;

    void Start()
    {
        puntuacion = 0;
    }

    void Update()
    {
        if (puntuacion >= 11)
        {
            CambiarDeEscena();
        }
    }

    public void IncrementarPuntuacion()
    {
        puntuacion++;
        Debug.Log("Puntuación actual: " + puntuacion);
    }

    void CambiarDeEscena()
    {
        Debug.Log("Puntuación alcanzada, cambiando a la siguiente escena.");
        SceneManager.LoadScene("Mapa 6");
    }
}
