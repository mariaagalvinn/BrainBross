using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogoToad2 : MonoBehaviour
{
    public Canvas dialogoToad;
    public Text textoDialogo;
    // Cambia las frases según tu juego
    private string[] frases = {
        "¡Hola de nuevo! Ahora te toca el siguiente minijuego.",
        "Para superarlo tienes que conseguir atravesar 20 carriles.",
        "Puedes moverte pulsando a, w, s, d.",
        "Ten cuidado. Los árboles te impiden pasar. Los coches te atropellan. Y, si no pasas a través de las hojas, te hundes.",
        "¡Buena suerte!"
    };
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
            SceneManager.LoadScene("CrossingRoad");
        }
    }
}
