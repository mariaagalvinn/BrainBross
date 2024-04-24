using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DianaDisparos3 : MonoBehaviour
{
    private void OnEnable()
    {
        Diana3.disparosActualizados+=ActualizarDisparos;
    }

    private void OnDisable()
    {
        Diana3.puntuacionActualizada-=ActualizarDisparos;
    }

    private void ActualizarDisparos(int disparos)
    {
        GetComponent<Text>().text = $"Disparos restantes: {disparos}";
    }
}
