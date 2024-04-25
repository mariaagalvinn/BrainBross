using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class Jugador : MonoBehaviour
{
    // Variables públicas
    public float velocidad = 7.0f;
    public Text comentario;

    // Variables privadas
    private Vector3 DireccionActual;
    private Rigidbody rb;
    private Vector3 posicionInicial; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        posicionInicial = transform.position; // Guarda la posición inicial

    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // Si el jugador presiona alguna tecla de movimiento
        if (horizontalInput != 0 || verticalInput != 0)
        {
            CambiarDireccion(horizontalInput, verticalInput);
        }
        transform.Translate(DireccionActual * velocidad * Time.deltaTime);
    }

    void CambiarDireccion(float horizontalInput, float verticalInput)
    {
        Vector3 direccionDeseada = Vector3.zero;

        // Determinar la dirección deseada
        if (horizontalInput > 0)
        {
            direccionDeseada += Vector3.right;
            comentario.text = "Gira a la derecha";
        }
        else if (horizontalInput < 0)
        {
            direccionDeseada += -Vector3.right;
            comentario.text = "Gira a la izquierda";
        }

        if (verticalInput > 0)
        {
            direccionDeseada += Vector3.forward;
            comentario.text = "Avanza hacia adelante";
        }
        else if (verticalInput < 0)
        {
            direccionDeseada += -Vector3.forward;
            comentario.text = "Retrocede";
        }
        DireccionActual = direccionDeseada.normalized;

    }

    // Método para cargar un archivo MP4 y extraer su audio
    public void CargarArchivoMP4(string filePath)
    {
        // Comprueba si el archivo seleccionado es un archivo MP4
        if (filePath.ToLower().EndsWith(".mp4"))
        {
            // Utiliza FFmpeg para extraer el audio del MP4
            string command = string.Format("ffmpeg -i \"{0}\" -vn -acodec pcm_s16le -ar 44100 -ac 2 \"{1}\"", filePath, Application.persistentDataPath + "/audio.wav");

            ProcessStartInfo info = new ProcessStartInfo("cmd.exe", "/c " + command);
            info.CreateNoWindow = true;
            info.UseShellExecute = true;

            Process.Start(info);
        }
    }
}
