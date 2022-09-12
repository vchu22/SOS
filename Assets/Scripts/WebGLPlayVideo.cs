using UnityEngine;
using UnityEngine.Video;

public class WebGLPlayVideo : MonoBehaviour
{
    VideoPlayer videoPlayer;
    public string url;

    public GameObject screen1;
    public GameObject screen2;

    // Use this for initialization
    void Start()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            screen1.SetActive(false);
            screen2.SetActive(true);

            //videoPlayer = GetComponent<VideoPlayer>();
            //videoPlayer.url = url;
            //videoPlayer.Play();
        }
    }
}
