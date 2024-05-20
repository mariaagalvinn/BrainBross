using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cronometro : MonoBehaviour
{
    private float tiempoTranscurrido = 0f;
    private bool corriendo = false;
    public float duracion = 60f; // Duración en segundos

    void Update()
    {
        if (corriendo)
        {
            tiempoTranscurrido += Time.deltaTime;
            if (tiempoTranscurrido >= duracion)
            {
                tiempoTranscurrido = duracion;
                corriendo = false;
                Debug.Log("El temporizador ha terminado");
                SceneManager.LoadScene(2);
            }
        }
    }

    public void IniciarTemporizador()
    {
        corriendo = true;
    }

    public void DetenerTemporizador()
    {
        corriendo = false;
    }

    public void ReiniciarTemporizador()
    {
        tiempoTranscurrido = 0f;
        corriendo = false;
    }

    public float ObtenerTiempoTranscurrido()
    {
        return tiempoTranscurrido;
    }

    public float ObtenerTiempoRestante()
    {
        return Mathf.Max(duracion - tiempoTranscurrido, 0f);
    }
}
