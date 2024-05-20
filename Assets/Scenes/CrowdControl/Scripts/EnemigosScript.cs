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
            scoreText.text =  enemigos.ToString();
        }

        private void Update() {
            scoreText.text = enemigos.ToString();
        }

        public void disparoEnemy(){
            if(enemigos > 0){
                enemigos--;
            }
        }

        public int getEnemigos(){
            return enemigos;
        }
    }
}
