using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hojas : MonoBehaviour
{
    public GameObject hoja;
    void Start()
    {
        LanzarRayo();
    }

    void Update()
    {
        
    }

    public void LanzarRayo()
    {
        RaycastHit hit;
        Ray rayo = new Ray(transform.position+Vector3.up*3-Vector3.forward, Vector3.down);

        if(Physics.Raycast(rayo, out hit))
        {
            if(hit.collider.CompareTag("Agua"))
            {
                Instantiate(hoja, transform.position - Vector3.forward, transform.rotation);
            }
            else if(hit.collider.CompareTag("obstaculo"))
            {
                Destroy(hit.transform.gameObject);
            
            }
        }
    }
}
