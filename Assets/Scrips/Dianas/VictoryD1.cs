using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryD1 : MonoBehaviour
{
    public Button boton;

    void Start()
    {
        boton.onClick.AddListener(Onclick);
    }

    public void Onclick()
    {
        SceneManager.LoadScene("Dianas2");
    }
}
