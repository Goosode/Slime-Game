using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCollect : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private int value = -1;
    private void OnTriggerEnter2D(Collider2D target) {
        if (target.gameObject.CompareTag("Player")){

            Destroy(gameObject);
            GoldRemaining.instance.IncreaseGold(value);

            audioManager.PlaySFX(audioManager.Collecting);
        }
    }
}
