using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void PlayGame() {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            SceneManager.LoadScene("03-GameScene1");
        } else {
            SceneManager.LoadScene("02-OpeningScene");
        }
    }

    public void OpenSettings() {

    }

    public void QuitGame() {
        Debug.Log("Quitting game.");
        Application.Quit();
    }
}
