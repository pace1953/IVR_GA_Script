using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;

public class VideoEndAction : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public UnityEvent finishEvent;

    void Start()
    {
        videoPlayer.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        finishEvent.Invoke();
    }
}

