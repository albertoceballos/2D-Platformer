using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour { 

    private void Awake()
    {
        ScoreManager.GetInitialHighScore();
    }

    public static void GameOver()
    {
        ScoreManager.SetHighScore();
        SceneManager.LoadScene("GameOver");
    }

    private static bool GamePaused = false;

    public static void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public static void QuitGame()
    {
        Application.Quit();
    }

    public static void PauseGame()
    {
        if (!GamePaused)
        {
            Time.timeScale = 0;
            GamePaused = true;
        }
        else
        {
            Time.timeScale = 1;
            GamePaused = false;
        }
    }

}
