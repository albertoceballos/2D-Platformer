using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

	public void StartGame()
    {
        GameManagerScript.StartGame();
    }

    public void QuitGame()
    {
        GameManagerScript.QuitGame();
    }

    public void PauseGame()
    {
        GameManagerScript.PauseGame();
    }
}
