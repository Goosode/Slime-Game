using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Burst.Intrinsics;

public class GoldRemaining : MonoBehaviour
{
    public static GoldRemaining instance;
    public GameScreenManager gameManager; 
    public TMP_Text GoldText;

    private int currentGold = 900;
    AudioManager audioManager;
    

    void Awake() {
        instance = this;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GoldText.text = "Gold remaining: " + currentGold.ToString();
    }

    // Update is called once per frame
    public void IncreaseGold(int v){
        currentGold += v;
        GoldText.text = "Gold remaining: " + currentGold.ToString();

        if(currentGold <= 0){
            audioManager.PlaySFX(audioManager.Win);
            audioManager.stopBGM();
            
            gameManager.gameWin();
            Time.timeScale = 0f;
        } 
    }
}
