using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerController2 : MonoBehaviour
{
    public Camera camara;
    public Transform playerPosicion;
    public Animator animator;
    public Transform[] plataformas;
    
    private Vector3 offset;
    private Vector3 targetPosition;
    private int index;
    private bool enMovimiento;
    private bool isJumping;
    public int indexJuego;
    public string nombreJuego;

    public float velocidadMovimiento = 10f; 
    public float distanciaMinima = 1f; 
    public float jumpHeight = 2f;
    public float jumpSpeed = 4f;
    public AudioSource jumpSound;


    void Start()
    {
        // Inicializar el índice de la plataforma actual
        offset = camara.transform.position - playerPosicion.position;
        jumpSound.gameObject.SetActive(false);
        // booleanos
        enMovimiento = false;
        isJumping = false;

        index = 0;
    }

    void Update(){
        Debug.Log(index);

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

            StartCoroutine(Jump()); // Empieza el salto
            
            if(Vector3.Distance(transform.position, targetPosition) < 6)
            {
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
            jumpSound.gameObject.SetActive(true);
            jumpSound.Play();
            animator.SetBool("isJumping", true);
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
            
            animator.SetBool("isJumping", false);
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
        if(index == indexJuego){
            SceneManager.LoadScene(nombreJuego);
        } 
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
