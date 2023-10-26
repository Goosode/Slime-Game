using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameScreenManager gameManager; 

    AudioManager audioManager;

    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D player) {
        if (player.gameObject.CompareTag("Enemy")){
            HealthManager.health--;

            if(HealthManager.health <= 0 ){
                gameManager.gameOver();
                Time.timeScale = 0f;

                audioManager.PlaySFX(audioManager.Fail);
                audioManager.stopBGM();
            }
        }
    }
}
