using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotonGameOverD3 : MonoBehaviour
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
