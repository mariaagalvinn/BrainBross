using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movCoche : MonoBehaviour
{
    public float velocidad = 2f; // Velocidad de movimiento
    private Rigidbody rb;
    private bool estaSeleccionado = false;
    
    private Coroutine miCorutina;
    private FIn controlador;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controlador = FindObjectOfType<FIn>();
        if (controlador == null)
        {
            Debug.LogError("No se encontró el controlador FIn en la escena.");
        }
    }

    
    void FixedUpdate()
    {

        // Detectar clic del ratón
        if (Input.GetMouseButtonDown(0))
        {
            // Rayo desde la cámara hacia la posición del ratón
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Verificar si el rayo golpea un collider
            if (Physics.Raycast(ray, out hit))
            {
                // Verificar si el collider pertenece al GameObject asociado al script
                if (hit.collider.gameObject == gameObject)
                {
                    Debug.Log("Se hizo clic en este GameObject");
                    estaSeleccionado = !estaSeleccionado;

                    if (estaSeleccionado)
                    {
                        Debug.Log("Activo movimiento");
                        miCorutina = StartCoroutine(AverSiSeMueve());
                    }
                    else
                    {
                        Debug.Log("descativado  movimiento");
                        StopCoroutine(miCorutina);
                        miCorutina = StartCoroutine(AverSiSePara());
                    }
                }
            }
        }

    }

    IEnumerator AverSiSeMueve()
    {
        while (estaSeleccionado)
        {
            // Obtener entrada de movimiento del eje vertical (W/S o Flechas arriba/abajo)
            float movimientoZ = Input.GetAxis("Vertical");

            // Calcular el movimiento
            Vector3 movimiento = transform.forward * movimientoZ * velocidad * Time.deltaTime;

            // Mover el coche
            rb.MovePosition(rb.position + movimiento);


            yield return null;
        }
    }

    IEnumerator AverSiSePara()
    {
        while (!estaSeleccionado)
        {
            yield return null;
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto con el que se colisiona tiene es suelo
        if (other.CompareTag("suelo"))
        {
            // Iniciar la rutina para desactivar el coche después de 2 segundos
            StartCoroutine(cocheFuera(0.3f));
             // Llamar al método para incrementar la puntuación
            controlador.IncrementarPuntuacion();

        }
    }

    // Rutina para desactivar el coche después de un retraso
    IEnumerator cocheFuera(float delay)
    {
        yield return new WaitForSeconds(delay);
        // Desactivar el GameObject del coche
        gameObject.SetActive(false);
    }

    void CambiarDeEscena()
    {
        Debug.Log("Puntuación alcanzada, cambiando a la siguiente escena.");
        SceneManager.LoadScene(2); // Cambiar de escena, ajusta el índice según sea necesario
    }

}
