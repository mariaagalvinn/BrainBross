using UnityEngine;
using UnityEngine.UI;

public class DialogoToad : MonoBehaviour
{
    public Canvas dialogoToad;
    public Text textoDialogo;
    private string[] frases = {
        "¡Hola! Te ha tocado jugar a tu primer minijuego.",
        "Para superarlo tienes que matar a tantos enemigos como indica el contador de la esquina izquierda.",
        "Si ves que el contador llega a 0 o a menos cuando pases la meta ¡Has ganado!, de lo contrario deberás volverlo a intentar.",
        "Puedes moverte arrastrando el ratón de izquierda a derecha por la pantalla.",
        "¡Buena suerte!"
    };
    private int indice = 0;
    //public BakedDataTest bakedDataTest;
    public Button button;
    private bool dialogoActivo = true;

    void Start()
    {
        Time.timeScale = 0f; // Pausa el juego
        // Mostrar la primera frase al iniciar
        MostrarSiguienteFrase();
        
    }

    void Update()
    {
        // Si el diálogo está activo, bloquear la interacción del usuario
        if (dialogoActivo)
        {
            Time.timeScale = 0f; // Pausa el juego
        }
        else
        {
            Time.timeScale = 1f; // Reanuda el juego
        }
    }

    public void onClick()
    {
        MostrarSiguienteFrase();
    }

    void MostrarSiguienteFrase()
    {
        // Comprueba si aún quedan frases por mostrar
        if (indice < frases.Length)
        {
            // Muestra la siguiente frase y avanza el índice
            textoDialogo.text = frases[indice];
            //bakedDataTest.PlayBakedData(indice);
            indice++;
        }
        else
        {
            // Si no quedan más frases, desactiva el diálogo
            dialogoToad.gameObject.SetActive(false);
            dialogoActivo = false;
            Time.timeScale = 1f;
        }
    }
}
