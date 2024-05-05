using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryD2 : MonoBehaviour
{
    public Button boton;

    void Start()
    {
        boton.onClick.AddListener(Onclick);
    }

    public void Onclick()
    {
        SceneManager.LoadScene("Dianas3");
    }
}
