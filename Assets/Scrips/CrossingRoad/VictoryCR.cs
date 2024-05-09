using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryCR : MonoBehaviour
{
    public Button boton2;

    void Start()
    {
        boton2.onClick.AddListener(Onclick2);
    }

    public void Onclick2()
    {
        SceneManager.LoadScene("Mapa 2");
    }
}
