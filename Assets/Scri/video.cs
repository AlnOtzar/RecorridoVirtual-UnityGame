using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Videos : MonoBehaviour
{
    public VideoPlayer video;

    void Start()
    {
        video = GetComponent<VideoPlayer>();
        video.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        video.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        video.Stop();
    }
}