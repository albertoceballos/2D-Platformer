using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {
    private void Awake()
    {
        var highScoreTextUI = GameObject.Find("HighScore").GetComponent<Text>();
        highScoreTextUI.text = PlayerPrefs.GetInt("HighScore").ToString();
    }
}
