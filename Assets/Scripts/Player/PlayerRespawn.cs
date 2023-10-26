using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    Vector2 startPos;
    Animator animator;
    Rigidbody2D rb;
    AudioManager audioManager;

    void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        startPos = transform.position;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D player) {
        if(player.gameObject.CompareTag("Enemy")){
            Die();
            audioManager.PlaySFX(audioManager.Death);
        }
    }

    void Die(){
        StartCoroutine(Respawn(0.8f));
    }

    IEnumerator Respawn(float duration){
        rb.simulated = false;
        rb.velocity = new Vector2(0, 0);
        animator.SetTrigger("isDead");
        yield return new WaitForSeconds(duration);
        transform.position = startPos;
        rb.simulated = true;
    }
}
