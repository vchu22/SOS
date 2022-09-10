using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ChangeScreen : MonoBehaviour
{
    VideoPlayer videoPlayer;
    [SerializeField] GameObject OpeningVideo;
    [SerializeField] GameObject PlayerStory;

    private void Start()
    {
        videoPlayer = GameObject.Find("Video Player").GetComponent<UnityEngine.Video.VideoPlayer>();
    }
    void Update() {
        // Before the video start, the video isPlaying is false. So we need to check whether the played
        // is beyond 0 to determine if we reached the end of the video
        if (!videoPlayer.isPlaying & videoPlayer.clockTime > 0)
        {
            OpeningVideo.SetActive(false);
            PlayerStory.SetActive(true);
        }
    }
    
}
