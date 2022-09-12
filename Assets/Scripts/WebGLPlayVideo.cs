using UnityEngine;
using UnityEngine.Video;

public class WebGLPlayVideo : MonoBehaviour
{
    VideoPlayer videoPlayer;
    [SerializeField] string url;
    // Use this for initialization
    void Start()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            videoPlayer = GetComponent<VideoPlayer>();
            videoPlayer.url = url;
            videoPlayer.Play();
        }
    }
}
