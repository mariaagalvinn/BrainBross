using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pantallainicial : MonoBehaviour
{
    public Canvas canvas;

    // dialogo
     
    public Canvas peach;
    public Text textoPeach;
    public Canvas bowser;
    public Text textoBowser;

    private int index;

    private void Start() {
        canvas.gameObject.SetActive(true);
       Debug.Log(index);
    }

    public void Onclick(){
        //Esconder Canvas
        canvas.gameObject.SetActive(false);
        //Mostrar dialogo
        index = 0;
        dialogo();
    }

    // dialogo
    public void dialogo(){
        if(index == 0){
            peach.gameObject.SetActive(true);
            textoPeach.text = "¡Bowser! ¿Qué estás tramando esta vez?".ToString();
        } else if(index == 1) {
            peach.gameObject.SetActive(false);
            bowser.gameObject.SetActive(true);
            textoBowser.text = "¡Ja, ja, ja! ¡Princesa Peach! ¡He venido a conquistar este reino!".ToString();
        } else if(index == 2){
            bowser.gameObject.SetActive(false);
            peach.gameObject.SetActive(true);
            textoPeach.text = "¡No lo permitiré!".ToString();
        } else if(index == 3){
            peach.gameObject.SetActive(false);
            bowser.gameObject.SetActive(true);
            textoBowser.text = "Bueno, veamos quién es el más astuto en mi BrainBross. ¡Prepárate para ser derrotada, Peach!".ToString();
        } else if(index == 4){
            bowser.gameObject.SetActive(false);
            peach.gameObject.SetActive(true);
            textoPeach.text = "¡No me rendiré! ¡Te voy a derrotar!".ToString();
        } else {
            peach.gameObject.SetActive(false);
            SceneManager.LoadScene("Mapa");
        }
        
    }

    public void AvanzarDialogoPeach()
    {
        index++;
        dialogo();
    }

    // Método para avanzar en el diálogo cuando se presiona el botón de Bowser
    public void AvanzarDialogoBowser()
    {
        index++;
        dialogo();
    }

}
