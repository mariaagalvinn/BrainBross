using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace bb {
    public class EnemigosScript : MonoBehaviour
    {
        public Text scoreText;
        private int enemigos = 50;

        private void Start() {
            scoreText.text = "Enemigos: " + enemigos;
        }

        private void Update() {
            scoreText.text = "Enemigos: " + enemigos;
        }

        public void disparoEnemy(){
            enemigos = enemigos - 1;
        }

        public int getEnemigos(){
            return enemigos;
        }
    }
}
