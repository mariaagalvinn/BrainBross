using System;
using UnityEngine;


public class MoveForward : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    

    private void Update()
    {
        transform.position += Vector3.forward * (moveSpeed * Time.deltaTime);
    }

    public void StopMoving()
    {
        moveSpeed = 0f;
    }

    public void ContinueMoving()
    {
        moveSpeed = 6f;
    }
}
