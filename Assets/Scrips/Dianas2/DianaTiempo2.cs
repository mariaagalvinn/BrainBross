using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DianaTiempo2 : MonoBehaviour
{
    private void OnEnable()
    {
        Diana2.tiempoActualizado+=ActualizarTiempo;
    }

    private void OnDisable()
    {
        Diana2.tiempoActualizado-=ActualizarTiempo;
    }

    private void ActualizarTiempo(int tiempo)
    {
        if(tiempo==0) GetComponent<Text>().text = "Tiempo acabado.";
        else GetComponent<Text>().text = $"Tiempo restante: {tiempo:F2}";

    }
}
