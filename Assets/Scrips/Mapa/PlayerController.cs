using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float distanciaMinima = 0.5f; // Distancia mínima para considerar que el jugador está sobre una plataforma
    private Rigidbody rb;
    private PlatformController plataformaActual; // La plataforma actual sobre la que está el jugador

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Verificar si el jugador está sobre una plataforma
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, distanciaMinima) && hit.collider.CompareTag("Platform"))
        {
            plataformaActual = hit.collider.GetComponent<PlatformController>();
        }
        else
        {
            plataformaActual = null;
        }

        // Permitir saltar si el jugador está en la posición correcta y presiona la tecla de salto
        if (plataformaActual != null && Input.GetKeyDown(KeyCode.Space))
        {
            // Obtener la dirección hacia la siguiente plataforma
            Vector3 direccionSiguiente = plataformaActual.ObtenerDireccionSiguiente();

            // Aplicar una fuerza hacia la siguiente plataforma para simular un salto
            rb.AddForce(direccionSiguiente.normalized * jumpForce, ForceMode.Impulse);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            Debug.Log("¡Has aterrizado en una plataforma!");
        }
    }
}
