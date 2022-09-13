using UnityEngine;
using UnityEngine.Video;

public class WebGLPlayVideo : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer videoPlayer;
    [SerializeField]
    private string videoFileName;

    // Use this for initialization
    void Start()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            videoPlayer = GetComponent<VideoPlayer>();
            videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
            videoPlayer.Play();
        }
    }
}
