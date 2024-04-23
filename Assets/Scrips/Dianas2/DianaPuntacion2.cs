using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DianaPuntacion2 : MonoBehaviour
{
    private void OnEnable()
    {
        Diana.puntuacionActualizada+=ActualizarPuntuacion;
    }

    private void OnDisable()
    {
        Diana.puntuacionActualizada-=ActualizarPuntuacion;
    }

    private void ActualizarPuntuacion(int puntos)
    {
        GetComponent<Text>().text = $"Puntuación: {puntos}";
    }
}

