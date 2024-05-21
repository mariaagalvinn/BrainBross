using System;
using Modifiers;
using UnityEngine;
using UnityEngine.SceneManagement;
using bb;
using BrainBross;


public class PlayerController : MonoBehaviour
{ 

    public GameObject moveForwardObject;
    public Canvas victoryCanvas;
    public Canvas darkCanvas;

    public AudioSource audioGanar;
    public AudioSource audioPerder;
    public AudioSource audioPpal;

    private MoveForward moveForwardScript;
    public PlayerShooter playerShooter;
    public EnemigosScript enemigos_;

    private PlayerCrowd pc;

    private void Start() {

        audioGanar.gameObject.SetActive(false);
        audioPerder.gameObject.SetActive(false);
        audioPpal.gameObject.SetActive(true);
    
        // Obtener el script de movimiento
        moveForwardScript = moveForwardObject.GetComponent<MoveForward>();
        // Ocultar el canvas de victoria
        victoryCanvas.gameObject.SetActive(false);    
    }

    private void Update()
    {
        if (PlayerCrowd.crowdSize == 0)
        {
            perder();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Modifier"))
        {
            var modifier = other.GetComponent<ModifierBase>();
            if (modifier)
            {
                modifier.Modify(this);
            }
        } else if (other.CompareTag("Meta"))
        {
            if(enemigos_.getEnemigos() <= 0){
                ganar();
            } else
            {
                perder();
            }
        }
    }
    public void StopGame(){
        moveForwardScript.StopMoving();
        playerShooter.StopShooting();
    }
    public void ContinueGame(){
        moveForwardScript.ContinueMoving();
        playerShooter.ContinueShooting();
    }

    private void ganar()
    {
        victoryCanvas.gameObject.SetActive(true);
        audioGanar.gameObject.SetActive(true);
        audioPpal.gameObject.SetActive(false);
        audioPerder.gameObject.SetActive(false);
        moveForwardScript.StopMoving();
        playerShooter.StopShooting();
    }

    private void perder()
    {
        audioPpal.gameObject.SetActive(false); // Desactiva el audio principal
        audioPerder.gameObject.SetActive(true);
        audioGanar.gameObject.SetActive(false);
        darkCanvas.gameObject.SetActive(true);
        moveForwardScript.StopMoving();
        playerShooter.StopShooting();
        GameManager.Instance.GameOver();
    }
    
}
