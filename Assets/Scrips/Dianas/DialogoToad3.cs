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
        "Con el ratón moverás la mira y haciendo click dispararás.",
        "Cada vez será más difícil y el valor aumentará.",
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
