using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DianaPuntacion3 : MonoBehaviour
{
    private void OnEnable()
    {
        Diana3.puntuacionActualizada+=ActualizarPuntuacion;
    }

    private void OnDisable()
    {
        Diana3.puntuacionActualizada-=ActualizarPuntuacion;
    }

    private void ActualizarPuntuacion(int puntos)
    {
        GetComponent<Text>().text = $"Puntuación: {puntos}";
    }
}

