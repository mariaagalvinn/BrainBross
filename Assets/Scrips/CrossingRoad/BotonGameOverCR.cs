using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotonGameOverCR : MonoBehaviour
{
    public Button boton1;

    void Start()
    {
        boton1.onClick.AddListener(Onclick1);
    }

    public void Onclick1()
    {
        SceneManager.LoadScene("CrossingRoad");
    }
}
