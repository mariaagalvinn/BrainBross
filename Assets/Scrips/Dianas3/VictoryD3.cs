using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryD3 : MonoBehaviour
{
    public Button boton;

    void Start()
    {
        boton.onClick.AddListener(Onclick);
    }

    public void Onclick()
    {
        SceneManager.LoadScene("Mapa 3");
    }
}
