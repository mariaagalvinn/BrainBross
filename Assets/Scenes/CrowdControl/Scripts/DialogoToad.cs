using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogoToad : MonoBehaviour
{
    public Canvas dialogoToad;
    public Text textoDialogo;
    // Cambia las frases según tu juego


    public  string[] frases;
    private int indice = 0;
    public BakedDataTest bakedDataTest;
    public Button button;
    
    void Start()
    {
        MostrarSiguienteFrase(); // Muestra la primera frase
    }
    
    public void onClick()
    {
        Debug.Log("Click");
        MostrarSiguienteFrase();
    }

    void MostrarSiguienteFrase()
    {
        // Comprueba si aún quedan frases por mostrar
        if (indice < frases.Length)
        {
            // Muestra la siguiente frase y avanza el índice
            textoDialogo.text = frases[indice];
            bakedDataTest.PlayBakedData(indice+1);
            indice++;
        }
        else {
            // Cambiar tu juego
            SceneManager.LoadScene("CrowdControl");
        }
    }
}
