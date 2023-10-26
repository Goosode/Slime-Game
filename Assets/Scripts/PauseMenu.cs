using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPause = false;
    public GameObject pauseUI;
    public GameObject settingUI;

    AudioManager audioManager;

    void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(gameIsPause){
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    public void Resume(){
        pauseUI.SetActive(false);
        settingUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPause = false;
    }

    void Pause(){
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPause = true;
    }
    
    public void mainMenu(){
        SceneManager.LoadScene("Main menu");
    }
}
