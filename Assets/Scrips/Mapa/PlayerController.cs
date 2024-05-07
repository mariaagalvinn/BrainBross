using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PersonajeController : MonoBehaviour
{
    public Camera camara;
    public Animator animator;
    public PlayerData playerData;
    public Transform[] plataformas;
    public Transform[] plataformasNubes;
    
    private Vector3 offset;
    private Vector3 targetPosition;
    private int index;
    private bool enMovimiento;
    private bool isJumping;

    public float velocidadMovimiento = 10f; 
    public float distanciaMinima = 1f; 
    public float jumpHeight = 2f;
    public float jumpSpeed = 4f;


    void Start()
    {
        // Cargar la posición de la plataforma actual del jugador
        int plataformaIndex = playerData.GetPlataforma();
        transform.position = plataformas[plataformaIndex].position;
        
        // Inicializar el índice de la plataforma actual
        offset = camara.transform.position - transform.position;

        // booleanos
        enMovimiento = false;
        isJumping = false;

        // Animaciones
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

            animator.SetBool("isGrounded", false);
            animator.SetBool("isJumping", true);
            StartCoroutine(Jump()); // Empieza el salto

            if(Vector3.Distance(transform.position, targetPosition) < distanciaMinima)
            {
                animator.SetBool("isFlying", false);
                animator.SetBool("isGrounded", true);

                enMovimiento = false;
                EntrarEnJuego();
            }
        } 

        camara.transform.position = transform.position + offset;
    }




    IEnumerator Jump()
    {

        if (!isJumping)
        {
            isJumping = true;

            Vector3 startPosition = transform.position;
            float time = 0f;

            animator.SetBool("isJumping", false);
            
            while (time < 1f)
            {
                float height = Mathf.Sin(Mathf.PI * time) * jumpHeight;
                transform.position = Vector3.Lerp(startPosition, targetPosition, time) + Vector3.up * height;
        
                animator.SetBool("isFlying", true);
                Debug.Log("Volando");

                time += Time.deltaTime * jumpSpeed;
                yield return null;
            }
            
            
            isJumping = false;
        }
    }

    void RotacionPersonaje()
    {

        float umbral = 20.0f;
        float rotationY = 0f;

        if(targetPosition.x > transform.position.x + umbral)
        {
            rotationY = 90f;
        }
        else if(targetPosition.x < transform.position.x - umbral)
        {
            rotationY = -90f;
        } 
        else if(targetPosition.z > transform.position.z + umbral)
        {
            rotationY = 0f;
            
        } 
        else 
        {
            rotationY = -180f;
        }

        transform.rotation = Quaternion.Euler(0, rotationY, 0);

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

}
