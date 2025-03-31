using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class Vide1 : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button playButton;
    public Button pauseButton;
    public Button stopButton;

    void Start()
    {
        videoPlayer.Stop(); // Asegurar que el video no se reproduzca al inicio

        // Asignar funciones a los botones
        playButton.onClick.AddListener(PlayVideo);
        pauseButton.onClick.AddListener(PauseVideo);
        stopButton.onClick.AddListener(StopVideo);
    }

    void PlayVideo()
    {
        videoPlayer.Play();
    }

    void PauseVideo()
    {
        videoPlayer.Pause();
    }

    void StopVideo()
    {
        videoPlayer.Stop();
    }
}
