using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Rigidbody))]

public class movPlayer : MonoBehaviour
{
    [SerializeField] private float _walkingSpeed = 3.0f;
    [SerializeField] private float _gravity = 20.18f;

    [SerializeField] private float _lookSpeed = 2.0f;
    [SerializeField] private float _lookXLimit = 25.0f;

    [SerializeField] public Camera playerCamera;
    [SerializeField] public CharacterController CharacterController;
    [SerializeField] private Vector3 _axis;
    [SerializeField] private float _rotation;

    [HideInInspector] private bool _canMove = true;

    public float tiempoASumar = 10f;
    public float tiempoARestar = 10f;
    

    public void Awake()
    {
        CharacterController = GetComponent<CharacterController>();

        //Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    public void Update()
    {
        Vector3 _forward = transform.TransformDirection(Vector3.forward);
        Vector3 _right = transform.TransformDirection(Vector3.right);

        float _cursorSpeedX = _canMove ? _walkingSpeed * Input.GetAxis("Vertical") : 0;
        float _cursorSpeedY = _canMove ? _walkingSpeed * Input.GetAxis("Horizontal") : 0;

        float _moveY = _axis.y;
        _axis = (_forward * _cursorSpeedX) + (_right * _cursorSpeedY);

        if(!CharacterController.isGrounded)
        {
            _axis.y -= _gravity * Time.deltaTime;
        }
        else
        {
            _axis.y = 0; // Reset vertical speed when grounded
        }

        CharacterController.Move(_axis * Time.deltaTime);

        if (_canMove)
        {
            _rotation += -Input.GetAxis("Mouse Y") * _lookSpeed;
            _rotation = Mathf.Clamp(_rotation, -_lookXLimit, _lookXLimit);

            playerCamera.transform.localRotation = Quaternion.Euler(_rotation, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * _lookSpeed, 0);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("mas"))
        {
            cronometroLaberinto cronometroScript = FindObjectOfType<cronometroLaberinto>();
            if (cronometroScript != null)
            {
                cronometroScript.SumarTiempo(tiempoASumar);
            }
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("menos"))
        {
            cronometroLaberinto cronometroScript = FindObjectOfType<cronometroLaberinto>();
            if (cronometroScript != null)
            {
                cronometroScript.RestarTiempo(tiempoARestar);
            }
            Destroy(other.gameObject);
        }

        else if (other.CompareTag("cambio"))
        {
            SceneManager.LoadScene(24);
        }

        else if (other.CompareTag("fin"))
        {
            SceneManager.LoadScene(3);
        }
    }
}
