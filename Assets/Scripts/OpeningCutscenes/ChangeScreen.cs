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
        Debug.Log(videoPlayer.clockTime);
        Debug.Log("OpeningVideoFinished " + OpeningVideoFinished + ", PlayerStoryFinished " + PlayerStoryFinished);

        if (!OpeningVideoFinished) {
            if (videoPlayer.isPlaying && Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                videoPlayer.Stop();
                SwitchScreen(OpeningVideo, PlayerStory, new bool[] { OpeningVideoFinished });
            }
            if (videoPlayer.clockTime >= 5)
            {
                SkipCutsceneText.SetActive(true);
            } else if (videoPlayer.clockTime >= 15)
            {
                SkipCutsceneText.SetActive(false);
            }
            // Before the video start, the video isPlaying is false. So we need to check whether the played
            // is beyond 0 to determine if we reached the end of the video
            if (!videoPlayer.isPlaying && videoPlayer.clockTime > 0)
            {
                SwitchScreen(OpeningVideo, PlayerStory, new bool[] { OpeningVideoFinished });
            }
        } else {
            Debug.Log("OpeningVideoFinished " + OpeningVideoFinished + ", PlayerStoryFinished " + PlayerStoryFinished);
            // Once finished playing all the player story dialogs in this scene, proceed to the game scene
            if (PlayerStoryFinished)
            {
                SceneManager.LoadScene("03-GameScene1");
            } else if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                PlayerStoryFinished = true;
            }
        }
    }

    private void SwitchScreen(GameObject screen1, GameObject screen2, bool[] sceneFinishedFlags)
    {
        screen1.SetActive(false);
        screen2.SetActive(true);
        for (int i=0; i<sceneFinishedFlags.Length; i++)
        OpeningVideoFinished = true;
    }
}
