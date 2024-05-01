using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionPeach : MonoBehaviour
{
   
   private Animator anim;
   private DialogoToad dialogoToad;

    void Start()
    {
        dialogoToad = FindObjectOfType<DialogoToad>();

        if(anim == null) anim = GetComponent<Animator>();

        if(anim == null) Debug.LogError("No se encontró el componente Animator");
        else Debug.Log("Se ha encontrado el componente Animator");

        Run();
    }

    private void Update()
    {
        if(dialogoToad.getIsPlaying() == false){
            Stop();
        }
    }

    public void Run()
    {
        Debug.Log("Run");
        anim.SetBool("isRunning", true);
    }

    public void Stop()
    {
        Debug.Log("Stop");
        anim.SetBool("isRunning", false);
    }
}
