using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DianaTiempo2 : MonoBehaviour
{
    private void OnEnable()
    {
        Diana.tiempoActualizado+=ActualizarTiempo;
    }

    private void OnDisable()
    {
        Diana.tiempoActualizado-=ActualizarTiempo;
    }

    private void ActualizarTiempo(int tiempo)
    {
        if(tiempo==0) GetComponent<Text>().text = "Fin de la partida";
        else GetComponent<Text>().text = $"Tiempo restante: {tiempo:F2}";

        if(tiempo < 3) GetComponent<Text>().color = Color.red;
    }
}