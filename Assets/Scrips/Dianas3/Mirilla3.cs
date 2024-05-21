using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirilla3 : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        GetComponent<RectTransform>().position = Input.mousePosition;
    }
}
