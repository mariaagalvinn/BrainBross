using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Movimiento movimiento;
    public float velocidad;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Vector3.forward*movimiento.carril, velocidad*Time.deltaTime);   
    }
}
