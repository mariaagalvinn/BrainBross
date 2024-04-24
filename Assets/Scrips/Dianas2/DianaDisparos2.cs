using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DianaDisparos2 : MonoBehaviour
{
    private void OnEnable()
    {
        Diana2.disparosActualizados+=ActualizarDisparos;
    }

    private void OnDisable()
    {
        Diana2.puntuacionActualizada-=ActualizarDisparos;
    }

    private void ActualizarDisparos(int disparos)
    {
        GetComponent<Text>().text = $"Disparos restantes: {disparos}";
    }
}
