using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PersonajeController : MonoBehaviour
{
    private Rigidbody rb;
    private PlatformController plataformaActual;
    private Vector3 targetPosition; // Posición a la que se moverá el personaje
    public float velocidadMovimiento = 10f; 
    private bool enMovimiento = false;
    public float distanciaMinima = 1f; // Distancia mínima para llegar a la posición deseada
    private bool isJumping = false;
    public float jumpHeight = 2f;
    public float jumpSpeed = 4f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Para evitar que se caiga de frente
    }

    void Update(){
        if(!enMovimiento && Input.GetKeyDown(KeyCode.RightArrow) && plataformaActual != null){
            // Debug.Log("El personaje se moverá a la siguiente plataforma.");
            // Posición a la que se moverá el personaje
            targetPosition = plataformaActual.ObtenerSiguientePlataforma().position;
            enMovimiento = true;
        }
        if(enMovimiento){
             // La velocidad a la que se moverá el personaje
            float step = velocidadMovimiento * Time.fixedDeltaTime; 
            StartCoroutine(Jump());
            //rb.MovePosition(Vector3.MoveTowards(transform.position, targetPosition, step));
            // Debug.Log("El personaje se está moviendo.");
            // Si ya llegamos a la posición deseada
            float distanceToTarget = Vector3.Distance(transform.position, targetPosition);
            //Debug.Log("Distancia al objetivo: " + distanceToTarget);
            if(distanceToTarget < distanciaMinima)
            {
                transform.position = targetPosition;
                enMovimiento = false;
                plataformaActual = null;
                Debug.Log("El personaje ha llegado a la posición deseada.");
            }
        } 
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform") && plataformaActual == null)
        {
            Debug.Log("El personaje está en contacto con la plataforma.");
            // Obtenemos la plataforma con la que colisionamos
            plataformaActual = collision.gameObject.GetComponent<PlatformController>();   
        }
    }

    IEnumerator Jump()
    {
        if (!isJumping)
        {
        
            isJumping = true;

            Vector3 startPosition = transform.position;

            float time = 0f;

            while (time < 1f)
            {
                float height = Mathf.Sin(Mathf.PI * time) * jumpHeight;
                transform.position = Vector3.Lerp(startPosition, targetPosition, time) + Vector3.up * height;
                time += Time.deltaTime * jumpSpeed;
                yield return null;
            }

            transform.position = this.targetPosition;
            isJumping = false;
        }
    }
}
