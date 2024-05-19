using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerLoss : MonoBehaviour
{
    private float _timer = 0f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            _timer += Time.deltaTime;
            if (_timer > SuikaGameManager.instance.TimeTillGameOver)
            {
                if (SuikaGameManager.instance.CurrentScore < 150)
                {
                    SuikaGameManager.instance.GameOver();
                }
                else
                {
                    SceneManager.LoadScene("Mapa 4");
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            _timer = 0f;
        }
    }
}
