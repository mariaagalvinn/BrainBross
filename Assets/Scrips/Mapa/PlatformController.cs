using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    
    public Transform siguientePlataforma; // Referencia al siguiente punto de destino

    // Método para obtener la dirección hacia la siguiente plataforma
    public Vector3 ObtenerDireccionSiguiente()
    {
        if (siguientePlataforma != null)
        {
            return siguientePlataforma.position - transform.position;
        }
        else
        {
            return Vector3.zero; // Si no hay una siguiente plataforma, retorna (0,0,0)
        }
    }
}


