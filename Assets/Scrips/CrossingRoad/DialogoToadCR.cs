using UnityEngine;
using UnityEngine.UI;

public class DialogoToadCR : MonoBehaviour
{
    public Canvas dialogoToad2;
    public Text textoDialogo2;
    private string[] frases2 = {
        "¡Hola de nuevo! Ahora te toca el siguiente minijuego.",
        "Para superarlo tienes que conseguir atravesar 20 carriles.",
        "Puedes moverte pulsando a, w, s, d.",
        "Ten cuidado con ciertos detalles. Los árboles te impiden pasar. Los coches te atropellan. Y, si no pasas a través de las hojas, te hundes.",
        "¡Buena suerte!"
    };
    private int indice2 = 0;
    public BakedDataTest bakedDataTest2;
    public Button button2;
    private bool dialogoActivo2 = true;

    void Start()
    {
        Time.timeScale = 0f; // Pausa el juego
        // Mostrar la primera frase al iniciar
        MostrarSiguienteFrase();
        
    }

    void Update()
    {
        // Si el diálogo está activo, bloquear la interacción del usuario
        if (dialogoActivo2)
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
        if (indice2 < frases2.Length)
        {
            // Muestra la siguiente frase y avanza el índice
            textoDialogo2.text = frases2[indice2];
            bakedDataTest2.PlayBakedData(indice2);
            indice2++;
        }
        else
        {
            // Si no quedan más frases, desactiva el diálogo
            dialogoToad2.gameObject.SetActive(false);
            dialogoActivo2 = false;
            Time.timeScale = 1f;
        }
    }
}
