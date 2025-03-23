using System.Collections;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras; // Lista de cámaras
    private int currentCameraIndex = 0;

    void Start()
    {
        // Activamos solo la primera cámara
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].enabled = (i == 0);
        }

        // Iniciamos el cambio de cámaras cada 5 segundos
        StartCoroutine(SwitchCameraRoutine());
    }

    IEnumerator SwitchCameraRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(7f); // Espera 5 segundos

            // Desactiva la cámara actual
            cameras[currentCameraIndex].enabled = false;

            // Cambia a la siguiente cámara
            currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;

            // Activa la nueva cámara
            cameras[currentCameraIndex].enabled = true;
        }
    }
}
