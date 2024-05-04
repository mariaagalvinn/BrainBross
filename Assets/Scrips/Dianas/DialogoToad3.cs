using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogoToad3 : MonoBehaviour
{
    public Canvas dialogoToad;
    public Text textoDialogo;
    // Cambia las frases según tu juego
    private string[] frases = {
        "¡Has llegado al primer nivel casita!",
        "Vas a tener que superar 3 niveles del minijuego dianas.",
        "Con el ratón podrás mover la mira y haciendo click podrás disparar.",
        "Cada vez será más difícil conseguir los puntos antes de que se acabe el tiempo. El valor de cada parte de la diana aumentará.",
        "¡Suerte!"
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
            SceneManager.LoadScene("Dianas");
        }
    }
}
