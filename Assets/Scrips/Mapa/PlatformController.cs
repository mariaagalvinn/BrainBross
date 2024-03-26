using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    
    public Transform siguientePlataforma; // Referencia al siguiente punto de destino

    public Transform ObtenerSiguientePlataforma()
    {
        return siguientePlataforma;
    }
    
}


