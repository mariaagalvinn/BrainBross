using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject gameOverUI;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void GameOver() {
        Time.timeScale = 0; // Pausa el juego
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
