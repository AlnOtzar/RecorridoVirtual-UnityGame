using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoControl : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button playPauseButton;
    
    void Start()
    {
        playPauseButton.onClick.AddListener(TogglePlayPause);
    }

    void TogglePlayPause()
    {
        if (!videoPlayer.isPlaying)
            videoPlayer.Play();
        else
            videoPlayer.Pause();
    }
}
