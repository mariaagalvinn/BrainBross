using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonGameOverCR : MonoBehaviour
{
    public void Onclick()
    {
        SceneManager.LoadScene("CrossingRoad");
    }
}
