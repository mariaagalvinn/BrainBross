using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionPeach : MonoBehaviour
{
   
   private Animator anim;
   private DialogoToad dialogoToad;

    void Start()
    {
        anim = GetComponent<Animator>();

        if(anim == null) Debug.LogError("No se encontró el componente Animator");
        else Debug.Log("Se ha encontrado el componente Animator");

         anim.SetBool("isRunning", true);
    }
}
