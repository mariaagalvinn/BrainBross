using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonGameOver : MonoBehaviour
{
    public void Onclick()
    {
        SceneManager.LoadScene("CrowdControl");
    }
}
