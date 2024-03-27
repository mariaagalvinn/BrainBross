using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PersonajeController : MonoBehaviour
{
    public Camera camara;
    private Vector3 offset;

    private Rigidbody rb;
    private PlatformController plataformaActual;

    private Vector3 targetPosition; // Posición a la que se moverá el personaje
    public float velocidadMovimiento = 10f; 
    private bool enMovimiento;
    public float distanciaMinima = 1f; // Distancia mínima para llegar a la posición deseada

    private bool isJumping = false;
    public float jumpHeight = 2f;
    public float jumpSpeed = 4f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Para evitar que se caiga de frente

        offset = camara.transform.position - transform.position;

        enMovimiento = false;
    }

    void Update(){

        if(!enMovimiento && Input.GetKeyDown(KeyCode.RightArrow) && plataformaActual != null){
            // Posición a la que se moverá el personaje
            targetPosition = plataformaActual.ObtenerSiguientePlataforma().position;
            enMovimiento = true;

            RotacionPersonaje();
        } 
        if(enMovimiento){
             // La velocidad a la que se moverá el personaje
            StartCoroutine(Jump());
            // Si ya llegamos a la posición deseada
            float distanceToTarget = Vector3.Distance(transform.position, targetPosition);
            if(distanceToTarget < distanciaMinima)
            {
                enMovimiento = false;
                plataformaActual = null;
                Debug.Log("El personaje ha llegado a la posición deseada.");
            }
        } 

        camara.transform.position = transform.position + offset;
    
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
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

            transform.position = targetPosition;
            isJumping = false;
        }
    }

    void RotacionPersonaje()
    {
        float umbral = 20.0f; // Ajusta este valor según sea necesario
        if(targetPosition.x > transform.position.x + umbral)
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        else if(targetPosition.x < transform.position.x - umbral)
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        } else if(targetPosition.z > transform.position.z + umbral){
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        } else {
            transform.rotation = Quaternion.Euler(0f, -180f, 0f);
        }

    }
}
