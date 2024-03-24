using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 nextDir;
    public Vector3 curPosition;
    public float speed = 5;
    public float speedroot = 10;
    public float rotationOffset;

    Rigidbody rb;

    public float jumpForce = 500;

    void Start()
    {
        rb = GetComponent<Rigidbody> ();
        curPosition=transform.position;
    }

    void Update()
    {
        if(transform.position!= new Vector3(curPosition.x, transform.position.y, curPosition.z)+nextDir)
        {
            transform.position=Vector3.MoveTowards(transform.position,  new Vector3(curPosition.x, transform.position.y, curPosition.z)+nextDir, speed*Time.deltaTime);

            transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.LookRotation(Quaternion.Euler(0,rotationOffset,0)*nextDir),speedroot*Time.deltaTime);
        }else
        {
            nextDir = Vector3.zero;
            curPosition=transform.position;
            curPosition.x = Mathf.Round (curPosition.x);
            curPosition.y=Mathf.Round(curPosition.y);
            if(Input.GetAxisRaw("Horizontal") != 0)
            {
                nextDir.z = Input.GetAxisRaw("Horizontal");
                Move();
            }
            else if (Input.GetAxisRaw("Vertical")!=0)
            {
                nextDir.x = Input.GetAxisRaw("Vertical");
                Move();
            }    
             if (Input.GetKeyDown(KeyCode.Space))
            {
                Move();
            }
        }

        
    }

    void Move()
    {
        // Aplicar una fuerza hacia arriba al Rigidbody para simular el salto
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }


}
