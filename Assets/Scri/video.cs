using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class Videos : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public float interactionDistance = 3f;
    public Transform playerCamera;
    public TextMeshProUGUI mensajeUI;

    private bool isPlaying = false;

    void Update()
    {
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.transform.gameObject == gameObject)
            {
                Debug.Log("Estoy mirando al botón");

                if (mensajeUI != null)
                {
                    mensajeUI.enabled = true;
                }

                // Reproducir/Pausar video
                if (Input.GetKeyDown(KeyCode.E))
                {
                    ToggleVideo();
                }
            }
            else
            {
                OcultarMensaje();
            }
        }
        else
        {
            OcultarMensaje();
        }
    }

    void ToggleVideo()
    {
        if (videoPlayer == null) return;

        if (isPlaying)
        {
            videoPlayer.Pause();
        }
        else
        {
            videoPlayer.Play();
        }

        isPlaying = !isPlaying;
    }

    void OcultarMensaje()
    {
        if (mensajeUI != null)
        {
            mensajeUI.enabled = false;
        }
    }
}
