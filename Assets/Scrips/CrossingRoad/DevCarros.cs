using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevCarros : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("carro"))
        {
            other.transform.Translate(0,0,-20);
        }
    }
}
