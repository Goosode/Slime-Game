using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScreenManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject gameWinUI;

    public void gameOver(){
        gameOverUI.SetActive(true);
    }

    public void gameWin(){
        gameWinUI.SetActive(true);
    }

    public void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void mainMenu(){
        SceneManager.LoadScene("Main menu");
        Time.timeScale = 1f;
    }
}