using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogoToad : MonoBehaviour
{
    public Canvas dialogoToad;
    public Text textoDialogo;
    // Cambia las frases según tu juego
    private string[] frases = {
        "¡Hola! Te ha tocado jugar a tu primer minijuego.",
        "Para superarlo tienes que matar a tantos enemigos como indica el contador de la esquina izquierda.",
        "Si ves que el contador llega a 0 o a menos cuando pases la meta ¡Has ganado!, de lo contrario deberás volverlo a intentar.",
        "Puedes moverte arrastrando el ratón de izquierda a derecha por la pantalla.",
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
            SceneManager.LoadScene("CrowdControl");
        }
    }
}
