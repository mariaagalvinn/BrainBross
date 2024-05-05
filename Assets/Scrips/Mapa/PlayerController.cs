using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PersonajeController : MonoBehaviour
{
    public Camera camara;
    private Vector3 offset;
    public Animator animator;
    public PlayerData playerData;

    private Vector3 targetPosition;

    public float velocidadMovimiento = 10f; 
    private bool enMovimiento;
    public float distanciaMinima = 1f; // Distancia mínima para llegar a la posición deseada
    public Transform[] plataformas;

    public Transform[] plataformasNubes;

    private int index;
    private bool isJumping = false;
    public float jumpHeight = 2f;
    public float jumpSpeed = 4f;



    void Start()
    {
        int plataformaIndex = playerData.GetPlataforma();
        transform.position = plataformas[plataformaIndex].position;
        offset = camara.transform.position - transform.position;

        enMovimiento = false;

        animator.SetBool("isGrounded", false); 
        animator.SetBool("isJumping", false);
        animator.SetBool("isFlying", false);
    }

    void Update(){

        if(!enMovimiento && Input.GetKeyDown(KeyCode.RightArrow)){
            
            incrementarIndex(); // Movemos el índice a la derecha
            targetPosition = plataformas[index].position;
            enMovimiento = true;
            RotacionPersonaje();
        } else if(!enMovimiento && Input.GetKeyDown(KeyCode.LeftArrow)){
            decrementarIndex(); // Movemos el índice a la izquierda
            targetPosition = plataformas[index].position;
            enMovimiento = true;
            RotacionPersonaje();
        }

        if(enMovimiento){
             // La velocidad a la que se moverá el personaje
            StartCoroutine(Jump());
            animator.SetBool("isGrounded", false);
            // Si ya llegamos a la posición deseada
            float distanceToTarget = Vector3.Distance(transform.position, targetPosition);
            if(distanceToTarget < distanciaMinima)
            {
                enMovimiento = false;
            }
        } 

        camara.transform.position = transform.position + offset;
    }

    void incrementarIndex()
    {
        if (index < plataformas.Length - 1)
        {
            index++;
        }
    }

    void decrementarIndex()
    {
        if (index > 0)
        {
            index--;
        }
    }

    

    IEnumerator Jump()
{
    if (!isJumping)
    {
        animator.SetBool("isGrounded", false);
        animator.SetBool("isJumping", true);

        isJumping = true;

        Vector3 startPosition = transform.position;
        float time = 0f;

        while (time < 1f)
        {
            float height = Mathf.Sin(Mathf.PI * time) * jumpHeight;
            transform.position = Vector3.Lerp(startPosition, targetPosition, time) + Vector3.up * height;

            // Actualizar estados de animación según el progreso del salto
            if (time < 0.5f)
            {
                animator.SetBool("isJumping", true);
                animator.SetBool("isFlying", false);
            }
            else
            {
                animator.SetBool("isJumping", false);
                animator.SetBool("isFlying", true);
            }

            time += Time.deltaTime * jumpSpeed;
            yield return null;
        }
        // Restablecer estados de animación al aterrizar
        animator.SetBool("isFlying", false);
        animator.SetBool("isGrounded", true);
        isJumping = false;

        // Vemos si se puede entrar en un juego
        EntrarEnJuego();
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

    void EntrarEnJuego(){
        bool jugado1 = false;
        if(index == 1 && !jugado1 && !isJumping){
            // Entrar en escena
            jugado1 = true;
            //playerData.SetPlataforma(index);
            //SceneManager.LoadScene("CrowdToad");
        } if(index == 12){
            camara.transform.position = new Vector3(379, 196, 161);
            camara.transform.rotation = Quaternion.Euler(11, 174, 0);
            StartCoroutine(SaltarEnNubes());

        }
    }

   IEnumerator SaltarEnNubes()
    {
        // Iterar sobre cada una de las plataformas de nube
        for (int i = 0; i < plataformasNubes.Length; i++)
        {
            // Establecer la posición de destino como la posición de la plataforma de nube actual
            targetPosition = plataformasNubes[i].position;

            // Esperar 5 segundos antes de saltar hacia la plataforma de nube actual
            yield return new WaitForSeconds(5f);

            // Saltar hacia la plataforma de nube actual
            StartCoroutine(Jump());

            // Esperar hasta que el personaje llegue a la plataforma de nube actual
            while(Vector3.Distance(transform.position, targetPosition) > distanciaMinima)
            {
                yield return null;
            }
        }

            // Si el personaje ha llegado a la plataforma de nube, cargar la siguiente escena
            SceneManager.LoadScene("CrowdToad");
    }



}
