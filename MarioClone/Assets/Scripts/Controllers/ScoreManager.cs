using UnityEngine;
using UnityEngine.UI;

public class ScoreManager{
    private static int score;
    private static int highScore;

    public static void GetInitialHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
    }

    public static void SetHighScore()
    {
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    public static void UpdateScore(int tscore)
    {
        score += tscore;
        var scoreUI = GameObject.Find("Score").GetComponent<Text>();
        scoreUI.text = score.ToString();
    }
}
