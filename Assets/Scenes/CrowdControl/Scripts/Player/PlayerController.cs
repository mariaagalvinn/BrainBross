using System;
using Modifiers;
using UnityEngine;
using UnityEngine.SceneManagement;
using bb;


public class PlayerController : MonoBehaviour
{
    public ParticleSystem victoryParticles;
    public GameObject moveForwardObject;
    public Canvas victoryCanvas;
    public Canvas darkCanvas;

    private MoveForward moveForwardScript;
    public PlayerShooter playerShooter;
    public EnemigosScript enemigos_;
    

    private void Start() {
        // Ocultar las partículas al inicio
        victoryParticles.Stop();
        victoryParticles.Clear();
        // Obtener el script de movimiento
        moveForwardScript = moveForwardObject.GetComponent<MoveForward>();
        // Ocultar el canvas de victoria

        victoryCanvas.gameObject.SetActive(false);    
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
                // Mostrar el canvas de victoria
                victoryCanvas.gameObject.SetActive(true);
                victoryParticles.Play();
                moveForwardScript.StopMoving();
                playerShooter.StopShooting();
            } else {
                darkCanvas.gameObject.SetActive(true);
                GameManager.Instance.GameOver();
            }
        }
    }
}
