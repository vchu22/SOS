using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene("03-GameScene1");
    }

    public void OpenSettings() {

    }

    public void QuitGame() {
        Debug.Log("Quitting game.");
        Application.Quit();
    }
}
