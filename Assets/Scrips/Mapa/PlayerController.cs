using UnityEngine;

public class PersonajeController : MonoBehaviour
{
    private Rigidbody rb;
    private PlatformController plataformaActual;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Para evitar que la gravedad lo haga caer
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            Debug.Log("El personaje está en contacto con la plataforma.");
            // Aquí puedes agregar cualquier lógica adicional que desees ejecutar cuando haya colisión con la plataforma.
            plataformaActual = collision.gameObject.GetComponent<PlatformController>();
            if (plataformaActual != null)
            {
                Debug.Log("Debemos moverlo a la siguiente plataforma: " + plataformaActual.ObtenerSiguientePlataforma().position);
                transform.position = plataformaActual.ObtenerSiguientePlataforma().position;
                
            }
        }
    }

    private void MoverPersonaje(Vector3 direccion)
    {
         rb.velocity = direccion.normalized * 5f;
    }
}
