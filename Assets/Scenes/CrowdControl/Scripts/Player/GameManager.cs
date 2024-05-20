using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public AudioSource audioGanar;
    public AudioSource audioPerder;
    public AudioSource audioPpal;
    public GameObject gameOverUI;

    private void Start()
    {
        audioGanar.gameObject.SetActive(false);
        audioPerder.gameObject.SetActive(false);
        audioPpal.gameObject.SetActive(true);
    }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void GameOver() {
        
        gameOverUI.SetActive(true); // Activa el panel de Game Over

    }

    public void RestartGame() {
        Time.timeScale = 1; // Reanuda el tiempo
        SceneManager.LoadScene("CrowdControl"); // Recarga la escena actual
    }

    public void BackToMapa(){
        Time.timeScale = 1; // Reanuda el tiempo
        SceneManager.LoadScene("Mapa 1"); // Carga la escena del mapa
    }
}
