using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cronometroLaberinto : MonoBehaviour
{

    public float tiempo = 60f;
    public Text textoTiempo;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    { 
        tiempo -= Time.deltaTime;
        textoTiempo.text = "Tiempo restante: " + tiempo.ToString("f0");

        if (tiempo <= 0.0f){
            SceneManager.LoadScene(1);
        }
    }

    public void SumarTiempo(float cantidad)
    {
        tiempo += cantidad;
    }

    public void RestarTiempo(float cantidad)
    {
        tiempo -= cantidad;
    }
    
}
