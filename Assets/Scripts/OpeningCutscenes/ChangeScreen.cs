using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class ChangeScreen : MonoBehaviour
{
    VideoPlayer videoPlayer;
    [SerializeField] GameObject OpeningVideo;
    [SerializeField] GameObject PlayerStory;
    [SerializeField] GameObject SkipCutsceneText;

    private bool OpeningVideoFinished;
    private bool PlayerStoryFinished;
    private void Start()
    {
        videoPlayer = GameObject.Find("Video Player").GetComponent<UnityEngine.Video.VideoPlayer>();
        OpeningVideoFinished = false;
        PlayerStoryFinished = false;
    }
    void Update() {
        // Before the video start, the video isPlaying is false. So we need to check whether the played
        // is beyond 0 to determine if we reached the end of the video
        Debug.Log(videoPlayer.clockTime);
        if (videoPlayer.isPlaying && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            videoPlayer.Stop();
            OpeningVideoFinished = true;
        }
        if (!videoPlayer.isPlaying && videoPlayer.clockTime > 0)
        {
            OpeningVideo.SetActive(false);
            PlayerStory.SetActive(true);
            OpeningVideoFinished = true;
        } else if (videoPlayer.clockTime >= 5)
        {
            SkipCutsceneText.SetActive(true);
        }
        if (videoPlayer.clockTime >= 15)
        {
            SkipCutsceneText.SetActive(false);
        }

        if (OpeningVideoFinished && !PlayerStoryFinished && Input.anyKeyDown)
        {
            PlayerStoryFinished = true;
        }

        // Once finished playing all the player story dialogs in this scene, proceed to the game scene
        if (OpeningVideoFinished && PlayerStoryFinished)
        {
            SceneManager.LoadScene("03-GameScene1");
        }
    }

    private void WaitForInput()
    {

    }
}
